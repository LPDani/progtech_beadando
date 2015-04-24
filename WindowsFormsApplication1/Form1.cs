using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        public List<pc> pcList = new List<pc>();
        public bus bus1;
        public Form1()
        {
            bus1 = new bus();

            pc pc1 = new pc();
            pc pc2 = new pc();

            pcList.Add(pc1);
            pcList.Add(pc2);

            InitializeComponent();

            label1.Text = pc1.state;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread t2 = new Thread(delegate()
            {
                pcList[0].send(bus1, pcList[0]); //send(bus bus1, pc pc1);
            });
            t2.Start();
            RefreshLabels();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //send(bus bus1, pc pc2);
            RefreshLabels();
        }


        public class pc
        {
            public string state;

            public pc()
            {
                state = "idle";
            }
            /*
 send(frame)
 wait_until (end_of_frame) or (collision)
 if collision detected:
 stop transmitting
 send(jamming)
 k = min (10, N)
 r = random(0, 2k - 1) * slotTime
 wait(r*slotTime)
             */



            public void send(bus bus1, pc act_pc)
            {
                act_pc.state = "want to send";
                wait(bus1);
                bus1.state = "start_send";
                // SO MUCH ANIMÁCIÓ
                // wait


                /*
                           if (state == "idle")
                           {
                               state = "want_to_send";
                               if (bus1.state.Equals("empty"))
                               {
                                   state = "start_send";
                                   bus1.state = "busy";
                                   state = "send";
                               }
                        
                           }
                 */

            }

            public void wait(bus bus1)
            {

                System.Threading.Thread.Sleep(1000);
                if (bus1.state != "empty")
                    wait(bus1);
            }
        }

        public class bus
        {
            public string state;

            public bus()
            {
                state = "empty";
            }
        }


        private void RefreshLabels()
        {
            label1.Text = pcList[0].state;
//            label1.Text = pcList[0].state;
        }

    }
}
