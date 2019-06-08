using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProjektDotNet
{
    
    public partial class Form1 : Form
    {
        string ID;
        public Form1()
        {
            InitializeComponent();

            /* Inicijalizacija combobox-eva ********************************************|| Enums: ||*** */
            comboBoxKvar.DataSource = Enum.GetValues(typeof(Nalog.TipKvara));        /* Tip Kvara       */
            comboBoxOdjel.DataSource = Enum.GetValues(typeof(Nalog.Odjel));          /* Odjel           */
            comboBoxStatus.DataSource = Enum.GetValues(typeof(Nalog.StatusKvara));   /* Status Kvara    */
            /********************************************************************************************/

            NaloziBazaEntities db = new NaloziBazaEntities();
            var nalozi = db.Nalozi;

            gridviewNalozi.DataSource = nalozi.ToList();

        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            //TODO: pritiskom na gumb "Promijeni" neka se pojavi prozor koji će izbaciti formu za upis passworda

            PopUpBox();

        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            //TODO: pritiskom na gumb, neka briše row u bazi // Unos

            NaloziBazaEntities db = new NaloziBazaEntities();

            PopUpBox();

            if (ControlID.validated)
            {
                string inv_broj = textBoxInvBroj.Text;
                if (inv_broj == "")
                {

                }

                var delNalog = new Nalozi()
                {
                    inv_br = inv_broj,
                    vrsta_kvara = comboBoxKvar.SelectedItem.ToString(),
                    odjel = comboBoxOdjel.SelectedItem.ToString(),
                    status = comboBoxStatus.SelectedItem.ToString()
                };
                db.Nalozi.Attach(delNalog);
                db.Nalozi.Remove(delNalog);

                db.SaveChanges();
            }

        }

        private void buttonIzbrisi_Click(object sender, EventArgs e)
        {
            //TODO: pritiskom na gumb, neka briše row u bazi // Nalozi

            NaloziBazaEntities db = new NaloziBazaEntities();
            PopUpBox();
            if (ControlID.validated)
            {
                var delNalog = new Nalozi() { nalogID = Guid.Parse(textBoxDeleteRow.Text) };
                db.Nalozi.Attach(delNalog);
                db.Nalozi.Remove(delNalog);

                db.SaveChanges();
                textBoxDeleteRow.Text = "";
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //TODO: pritiskom na gumb neka unosi novi row u bazu

            NaloziBazaEntities db = new NaloziBazaEntities();

            /***********************************************************************||NaloziBaza.mdf/Nalozi||*******/
            Guid guid = Guid.NewGuid();                                 /*  [nalogID]     UNIQUEIDENTIFIER NOT NULL*/
            string TipKvara = comboBoxKvar.SelectedItem.ToString();     /*  [vrsta_kvara] VARCHAR (20)     NOT NULL*/
            string Prijavio = textBoxPrijavio.Text;                     /*  [prijavio]    VARCHAR (30)     NULL    */
            string Odjel = comboBoxOdjel.SelectedItem.ToString();       /*  [odjel]       VARCHAR (10)     NOT NULL*/
            DateTime Time = DateTime.Now;                               /*  [datum]       DATETIME         NOT NULL*/
            string InvBroj = textBoxInvBroj.Text;                       /*  [inv_br]      VARCHAR(15)      NULL    */
            string Marka = textBoxMarka.Text;                           /*  [marka]       VARCHAR (30)     NULL    */
            string Status = comboBoxStatus.SelectedItem.ToString();     /*  [status]      VARCHAR (20)     NOT NULL*/
            string Napomena = richTextBoxOpis.Text;                     /*  [opis]        VARCHAR (255)    NULL    */
            /*******************************************************************************************************/

            Nalozi newNalog = new Nalozi();                             /* Novi entitet naloga za dodati           */

            /*******************************************************************************************************/
            newNalog.nalogID = guid;
            newNalog.vrsta_kvara = TipKvara;
            newNalog.prijavio = Prijavio;
            newNalog.odjel = Odjel;
            newNalog.datum = Time;
            newNalog.inv_br = InvBroj;
            newNalog.marka = Marka;
            newNalog.status = Status;
            newNalog.opis = Napomena;
            /*******************************************************************************************************/

            

            db.Nalozi.Add(newNalog);
            db.SaveChanges();
            var msgBox = MessageBox.Show("Pohranjeno.", "Done", MessageBoxButtons.OK);
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            NaloziBazaEntities db = new NaloziBazaEntities();
            var nalozi = db.Nalozi;

            gridviewNalozi.DataSource = nalozi.ToList();

        }

        public void PopUpBox()
        {
            PassPopUp validation = new PassPopUp();
            validation.Show();
            
        }
    }

}
