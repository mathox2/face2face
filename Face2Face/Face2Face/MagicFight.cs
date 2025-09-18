using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Face2Face
{
    public partial class MagicFight : Form
    {
        enum Sort
        {
            soin,
            volVie,
            degat,
            poison
        }


        public MagicFight()
        {
            InitializeComponent();
        }

        private void btnTirerJ1_Click(object sender, EventArgs e)
        {
            tirer(true);
        }

        private void btnTirerJ2_Click(object sender, EventArgs e)
        {
            tirer(false);
        }


        private void tirer(bool j1ATire)
        {
            Random rnd = new Random();
            int rand = rnd.Next(0, 4);
            Sort sort = (Sort)rand;

            if (sort != Sort.volVie)
            {
                lblSort.Text = $"Sort : {sort.ToString()}";
            }
            else
            {
                lblSort.Text = $"Sort : vol de vie";
            }

            rand = rnd.Next(0, 2);
            bool sortReussis = false;
            if (rand == 0)
            {
                lblEtat.Text = "État : Réussis";
                sortReussis = true;
            }
            else
            {

                lblEtat.Text = "État : Raté";
            }


            ProgressBar destinataire;
            int degats;

            if (sort == Sort.soin)
            {
                degats = 10;

                if (j1ATire && sortReussis || !j1ATire && !sortReussis)
                {
                    destinataire = pgbVieJ1;
                }
                else
                {
                    destinataire = pgbVieJ2;
                }
            }
            else
            {
                degats = -10;

                if (j1ATire && sortReussis || !j1ATire && !sortReussis)
                {
                    destinataire = pgbVieJ2;
                }
                else
                {
                    destinataire = pgbVieJ1;
                }
            }
            destinataire.Value += degats;
            inverserTour();
        }
        private void inverserTour()
        {
            bool tourActuel = btnSacrificeJ1.Enabled;

            btnSacrificeJ1.Enabled = !tourActuel;
            tbxChanceJ1.Enabled = !tourActuel;
            tbxPuissanceJ1.Enabled = !tourActuel;
            btnTirerJ1.Enabled = !tourActuel;

            btnSacrificeJ2.Enabled = tourActuel;
            tbxChanceJ2.Enabled = tourActuel;
            tbxPuissanceJ2.Enabled = tourActuel;
            btnTirerJ2.Enabled = tourActuel;
        }
    }
}
