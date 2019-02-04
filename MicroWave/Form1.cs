using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroWave
{
    public partial class Form1 : Form
    {
        protected bool MicrowaveStatus;
        protected static bool Door;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// To exit the application through menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Timer with interval = 1000 (1 second)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (MicrowaveStatus)
            {
                MicrowaveTimer.Instance.CountDown();
                microwaveTimer.Text = string.Format("{0}:{1}", MicrowaveTimer.Instance.Minute.ToString().PadLeft(2, '0'), MicrowaveTimer.Instance.Second.ToString().PadLeft(2, '0'));
            }
        }

        private void buttonPizza(object sender, EventArgs e)
        {
            AddDishTimer(60);
        }

        private void buttonPotato(object sender, EventArgs e)
        {
            AddDishTimer(120);
        }

        private void buttonVegetable(object sender, EventArgs e)
        {
            AddDishTimer(300);
        }

        private void buttonMeat(object sender, EventArgs e)
        {
            AddDishTimer(800);
        }

        /// <summary>
        /// Door control method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDoor(object sender, EventArgs e)
        {
            switch (Door)
            {
                case false:
                    Door = true;
                    MicrowaveStatus = false;
                    pictureBox1.Image = Properties.Resources.open_microwave;
                    break;
                case true:
                    Door = false;
                    MicrowaveStatus = true;
                    pictureBox1.Image = Properties.Resources.microwave;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Starting microwave with fast 30 seconds
        /// If microwave is paused, this method will continue the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStartAddSeconds(object sender, EventArgs e)
        {
            if (MicrowaveStatus || (MicrowaveTimer.Instance.Minute == 0 && MicrowaveTimer.Instance.Second == 0))
            {
                MicrowaveTimer.Instance.AddSeconds(30);
            }
            if (!Door)
            {
                MicrowaveStatus = true;
            }
        }

        /// <summary>
        /// Button to pause or if already paused, clearing method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPauseClear(object sender, EventArgs e)
        {
            if (!MicrowaveStatus)
            {
                MicrowaveTimer.Instance.CounterReset();
                microwaveTimer.Text = "00:00";
            }
            MicrowaveStatus = false;
        }

        /// <summary>
        /// Time adder for dishes
        /// </summary>
        /// <param name="seconds"></param>
        private void AddDishTimer(int seconds)
        {
            MicrowaveTimer.Instance.AddSeconds(seconds);
            MicrowaveStatus = true;
        }
    }
}
