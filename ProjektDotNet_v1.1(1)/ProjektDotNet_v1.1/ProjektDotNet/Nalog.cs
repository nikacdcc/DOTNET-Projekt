using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektDotNet
{
   class Nalog
    {
        
        private Guid nalogID;
        private string prijavio;
        private DateTime datum;
        private int invBroj;
        private string model;
        private string status;
        private string napomena;

        public Guid NalogID
        {
            get
            {
                return nalogID;
            }
            set
            {
                this.nalogID = value;
            }
        }
        public string Prijavio {
            get
            {
                return this.prijavio;
            }
            set
            {
                this.prijavio = value;
            }
        }
        public DateTime Datum
        {
            get
            {
                return this.datum;
            }
            set
            {
                this.datum = value;
            }
        }
        public int InvBroj
        {
            get
            {
                return this.invBroj;
            }
            set
            {
                this.invBroj = value;
            }
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }
        public string Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }
        public string Napomena
        {
            get
            {
                return this.napomena;
            }
            set
            {
                this.napomena = value;
            }
        }


        public enum TipKvara
        {
            Hardware,
            Software
        }
        public enum StatusKvara
        {
            Preuzeto,
            U_radu,
            Rijeseno
        }
        public enum Odjel
        {
            SGK,
            SKE,
            PPRP1,
            PPRP2,
            SKP,
            SOPK
        }


    }
}
