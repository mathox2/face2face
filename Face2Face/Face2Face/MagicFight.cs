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

        int degatJ1 = 10;
        int degatJ2 = 10;


        (ProgressBar bar, int tour, int degat) j1Empoisonne;
        (ProgressBar bar, int tour, int degat) j2Empoisonne;

        public MagicFight()
        {
            InitializeComponent();
            j1Empoisonne = (pgbVieJ1, 0, 0);
            j2Empoisonne = (pgbVieJ2, 0, 0);
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
            ProgressBar receveur;
            int degats = 0;

            if (j1ATire && sortReussis)
            {
                destinataire = pgbVieJ2;
                receveur = pgbVieJ1;
                degats = degatJ1;
            }
            else if (!j1ATire && !sortReussis)
            {

                destinataire = pgbVieJ2;
                receveur = pgbVieJ1;
                degats = degatJ2;
            }
            else if (!j1ATire && sortReussis)
            {
                destinataire = pgbVieJ1;
                receveur = pgbVieJ2;
                degats = degatJ2;
            }
            else
            {
                destinataire = pgbVieJ1;
                receveur = pgbVieJ2;
                degats = degatJ1;
            }

            if (sort == Sort.soin)
            {
                if (receveur.Value < 100)
                {
                    receveur.Value += degats;
                }
            }
            else if (sort == Sort.volVie)
            {
                if(receveur.Value < 100)
                {
                    receveur.Value += degats;
                }
                destinataire.Value -= degats;
            }
            else if (sort == Sort.poison)
            {
                if (destinataire == j1Empoisonne.bar)
                {
                    j1Empoisonne.tour = 5;
                    j1Empoisonne.degat = degats;
                }
                else
                {
                    j2Empoisonne.tour = 5;
                    j2Empoisonne.degat = degats;
                }
            }
            else
            {
                destinataire.Value -= degats;
            }
            updatePoison();
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

        private void updatePoison()
        {
            if(j1Empoisonne.tour > 1)
            {
                j1Empoisonne.tour -= 1;
                j1Empoisonne.bar.Value -= j1Empoisonne.degat;
                lblPoisonJ1.Visible = true;
                lblPoisonJ1.Text = "Tour poison restant " + j1Empoisonne.tour;
            }
            else
            {
                lblPoisonJ1.Visible = false;
            }
            if (j2Empoisonne.tour > 1)
            {

                j2Empoisonne.tour -= 1;
                j2Empoisonne.bar.Value -= j2Empoisonne.degat;
                lblPoisonJ2.Visible = true;
                lblPoisonJ2.Text = "Tour poison restant " + j2Empoisonne.tour;
            }
            else
            {
                lblPoisonJ2.Visible = false;
            }
        }
    }
}
