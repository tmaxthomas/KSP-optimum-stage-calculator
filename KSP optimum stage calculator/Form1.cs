//Copyright (c) 2017 Theodore M. Thomas

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace KSP_optimum_stage_calculator
{
    public partial class Form1 : Form
    {
        List<Engine> engines;
        double vessel_mass, payload_mass, min_accel;

        //Globals used by buildRocket to store best rocket config 
        List<Stage> best_rocket;
        double best_dv = 0;

        public Form1()
        {
            InitializeComponent();

            best_rocket = new List<Stage>();

            //Construct the list of available engines
            engines = new List<Engine>();
            engines.Add(new Engine("Spark", 0.1, 20.0, 320.0));
            engines.Add(new Engine("Terrier", 0.5, 60.0, 345.0));
            engines.Add(new Engine("Poodle", 1.75, 250.0, 350.0));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Grab inputs from the text boxes

            try //Or try to, anyways
            {
                vessel_mass = Convert.ToDouble(v_mass_box.Text);
                payload_mass = Convert.ToDouble(p_mass_box.Text);
                min_accel = Convert.ToDouble(min_accel_box.Text);
            }
            catch (FormatException) //Handle bad inputs
            {
                output_box.Text = "Error: Missing or improper inputs";
                return;
            }

            int max_stages = 2; //TEMPORARY-Replace with diminishing returns detection
            for(int a = 1; a <= max_stages; a++)
            {
                //Construct empty rocket for use by buildRocket & rest best_rocket, best_dv
                List<Stage> rocket = new List<Stage>();
                best_rocket = new List<Stage>();
                best_dv = 0;
                for(int b = 0; b < a; b++)
                {
                    rocket.Add(new Stage());
                }
                buildRocket(ref rocket, 0);
            }
            output_box.Text = rocketToString(ref best_rocket);
        }
        //Recursive optimum rocket-building method-puts optimum rocket in best_rocket global var
        void buildRocket(ref List<Stage> rocket, int stageNum)
        {
            foreach(Engine eng in engines)
            {
                rocket[stageNum].engine = eng;
                if(stageNum != rocket.Count - 1)
                {
                    buildRocket(ref rocket, stageNum+1); //Use recursion to simulate n-ary nested foreach loops
                }
                else //In here, do all of the math
                {
                    double x_sum = Math.Log(vessel_mass / payload_mass);
                    //Just use 1 as the initial guess
                    double x = 1;
                    double[] p_vals = new double[rocket.Count];
                    double[] t_vals = new double[rocket.Count];
                    //Compute p and t values for the rocket
                    for(int a = 0; a < rocket.Count; a++)
                    {
                        p_vals[a] = 9.80665 * rocket[a].engine.Isp;
                        t_vals[a] = (1.0 / 9.0) + (8.0 / 9.0) * (min_accel / rocket[a].engine.TWR);
                    }
                    double h = 0.00001;
                    //Newton's method
                    for (int a = 0; a < 10; a++)
                    {
                        double f_x = functionEval(ref p_vals, ref t_vals, rocket.Count, x) - x_sum;
                        double f_xh = functionEval(ref p_vals, ref t_vals, rocket.Count, x + h) - x_sum;
                        double df_dx = (f_xh - f_x) / h; //Numerically compute the derivative
                        x -= f_x / df_dx;
                    }
                    //Now that we have x_1, actually put the vehicle together
                    double[] x_vals = new double[rocket.Count];
                    //Grab all the x values
                    computeXSequence(ref x_vals, ref p_vals, ref t_vals, rocket.Count, x);
                    //Compute the delta-V
                    double delta_v = 0;
                    for(int a = 0; a < rocket.Count; a++)
                    {
                        delta_v += -p_vals[a] * Math.Log(t_vals[a] + (8.0 / 9.0) * Math.Pow(Math.E, -x_vals[a]));
                    }
                    if(delta_v > best_dv) //if the current rocket is better than the best rocket
                    {
                        //Compute stage masses
                        for(int a = 0; a < rocket.Count; a++)
                        {
                            double mp = 0, mv = 0; //Per-stage payload & vessel masses
                            if (a == 0)
                                mv = vessel_mass;
                            else
                                mv = rocket[a - 1].payload_mass;
                            mp = mv / Math.Pow(Math.E, x_vals[a]);
                            rocket[a].mass = mv - mp;
                            rocket[a].payload_mass = mp;
                        }

                        //Sanity check for vehicle mass
                        double test_mass = payload_mass;
                        for (int a = 0; a < rocket.Count; a++)
                            test_mass += rocket[a].mass;
                        Debug.Assert(Math.Abs(test_mass - vessel_mass) < .01);
                        best_dv = delta_v;
                        best_rocket = rocket;
                    }
                }
            }
        }
        //Fills array x[] with all the x's, as computed from the value of x_1.
        void computeXSequence(ref double[] x, ref double[] p, ref double[] t, int len, double x_1)
        {
            x[0] = x_1;
            for (int a = 1; a < len; a++)
            {
                //Since there's a relation connecting all x to all other x, we can derive the value of the sum of all x
                //from only the value of x1. However, the relation isn't clean. Hence, this mess.
                x[a] = Math.Log((8.0 * ((p[a - 1] / p[a]) * ((9.0 / 8.0) * t[a] * Math.Pow(Math.E, x[a - 1]) + 1.0) - 1.0)) / (9.0 * t[a]));
            }
        }

        //Computes the sum of all x from the value of x_1
        double functionEval(ref double[] p, ref double[] t, int len, double x)
        {
            double[] terms = new double[len];
            double ret = 0;
            computeXSequence(ref terms, ref p, ref t, len, x);
            for(int a = 0; a < len; a++)
            {
                ret += terms[a]; //Add up all the terms
            }
            return ret;
        }

        string rocketToString(ref List<Stage> rocket)
        {
            string ret = "";
            for(int a = 0; a < rocket.Count; a++)
                ret += "Stage " + Convert.ToString(a) + ": Mass " + Convert.ToString(rocket[a].mass) + " t, " + rocket[a].engine.name + " engine\n\n";
            return ret;
        }
    }

    //Container class for engines
    public class Engine
    {
        public Engine(string name, double mass, double thrust, double Isp)
        {
            this.name = name;
            this.mass = mass;
            this.thrust = thrust;
            this.Isp = Isp;
            TWR = thrust / mass;
        }
        public string name;
        public double mass, thrust, TWR, Isp;
        //The TWR is actually the thrust-to-mass ratio, since we're dealing in acceleration
    }

    //Container class for stages
    public class Stage
    {
        public Stage()
        {
            engine = null;
            num_engs = 0;
            mass = 0;
            payload_mass = 0;
        }
        public Stage(Engine engine, int num_engs, double mass, double payload_mass)
        {
            this.engine = engine;
            this.num_engs = num_engs;
            this.mass = mass;
            this.payload_mass = payload_mass;
        }
        public Engine engine;
        public int num_engs;
        public double mass, payload_mass;
    }
}
