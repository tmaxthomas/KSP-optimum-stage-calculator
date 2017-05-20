//Copyright c. 2017 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KSP_optimum_stage_calculator
{
    public partial class Form1 : Form
    {
        List<Engine> engines;
        public Form1()
        {
            InitializeComponent();
            engines.Add(new Engine("Spark", 0.1, 20.0, 320.0));
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }

    class Engine
    {
        public Engine(string name, double mass, double thrust, double Isp)
        {
            this.name = name;
            this.mass = mass;
            this.thrust = thrust;
            this.Isp = Isp;
            TWR = thrust / mass;
        }
        string name;
        double mass, thrust, TWR, Isp;
    }

    class Stage
    {
        public Stage(Engine engine, int num_engs, double mass)
        {
            this.engine = engine;
            this.num_engs = num_engs;
            this.mass = mass;
        }
        Engine engine;
        int num_engs;
        double mass;
    }
}
