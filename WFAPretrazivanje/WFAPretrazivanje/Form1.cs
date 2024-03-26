using System;
using System.Collections.Concurrent;
using System.IO;
using System.Management;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;


namespace WFAPretrazivanje
{
    public partial class Form1 : Form
    {
        string[] readText = null;
        string[] files = null;
        int brojTredova = 0;
        int brojPronadjenihFajlova = 0;
        DateTime pocetnoVrijeme = new DateTime();
        

        public Form1()
        {
            InitializeComponent();

            rbtnSekvencijalno.Checked = true;
            rbtnParalelno.Enabled = false;
            logoviRtxt.Text = "Selektujte folder za pretrazivanje";
            logoviRtxt.SelectAll();
            logoviRtxt.SelectionAlignment = HorizontalAlignment.Center;
            logoviRtxt.SelectionFont = new System.Drawing.Font("Arial", 16);
            logoviRtxt.DeselectAll();
            //Postavljanje tool tip-a za brisanje sadržaja konzole
            toolTipClear.SetToolTip(btnClear, "Ocisti konzolu");
            tredoviTxt.Text = Environment.ProcessorCount.ToString();

            //Cuvanje broja tredova radi podjele posla procesima
            brojTredova = Environment.ProcessorCount;
        }
       

        //Metoda za otvaranje Folder Browser dijaloga kako bi se selektovao folder sa tekstualnim fajlovima
        private void selectFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    if (files != null)
                    {
                        files = null;
                    }
                    txtUkupanBroj.Text = "0";
                    pronadjeniFajloviTxt.Text = "0";
                    txtVrijeme.Text = "0";

                    //Ucitavanje fajlova iz foldera koji smo selektovali (Filter za fajlove je .txt)
                    files = System.IO.Directory.GetFiles(fbd.SelectedPath, "*.txt");

                    pronadjeniFajloviTxt.Text = files.Length.ToString();
                    logoviRtxt.Text = ">Broj pronaðenih tekstulanih fajlova: " + files.Length.ToString() + "\n";

                    //Provjeravanje da li i koliko je .txt fajlova ucitano
                    if (files.Length == 0)
                    {
                        logoviRtxt.Text += ">Nije pronađen ni jedan teksutalni fajl.\n";
                        logoviRtxt.Text += "------------------------------------------------------------------------------------\n";
                    }
                    else if (files.Length < brojTredova)//Ukoliko postoji manje fajlova nego tredova paralelizacija nece igrati veliku ulogu u ubrzanju
                    {
                        pronadjeniFajloviTxt.Text = "Ucitavanje..";
                        logoviRtxt.Text += ">Optimizacija za ovaj broj fajlova nije potrebna.\n";
                        logoviRtxt.Text += "------------------------------------------------------------------------------------\n";
                        rbtnSekvencijalno.Checked = true;
                        rbtnParalelno.Enabled = false;
                        Thread thr = new Thread(new ThreadStart(procitajSveFajlove));//Kreiranje treda za ucitavanje sadrzaja fajlova
                        thr.Start();
                        pronadjeniFajloviTxt.Text = files.Length.ToString();

                        while (brojPronadjenihFajlova < files.Length - 1) ;

                        logoviRtxt.Text += "Ucitavanje fajlova uspješno završeno\n------------------------------------------------------------------------------------\n";

                    }
                    else
                    {
                        pronadjeniFajloviTxt.Text = "Ucitavanje..";
                        logoviRtxt.Text += ">Optimizacija za ovaj broj falova je moguca.\n";
                        logoviRtxt.Text += "------------------------------------------------------------------------------------\n";
                        rbtnSekvencijalno.Checked = true;
                        rbtnParalelno.Enabled = true;
                        Thread thr = new Thread(new ThreadStart(procitajSveFajlove));
                        thr.Start();
                        pronadjeniFajloviTxt.Text = files.Length.ToString();

                        while (brojPronadjenihFajlova < files.Length - 1) ;

                        logoviRtxt.Text += "Ucitavanje fajlova uspješno završeno\n------------------------------------------------------------------------------------\n";
                    }
                }
            }
        }

        private void procitajSveFajlove() //Metoda za citanje fajlova
        {

            readText = new String[files.Length];
            for (int i = 0; i < files.Length; i++)
            {

                readText[i] = File.ReadAllText(files[i]);
                brojPronadjenihFajlova = i;
            }

        }

        private void btnPretraga_Click(object sender, EventArgs e)
        {
            txtUkupanBroj.Text = 0 + "";
            logoviRtxt.Text = "";
            txtVrijeme.Text = "0";

            if (rbtnSekvencijalno.Checked == true)
            {
                if (readText != null)
                {
                    if (txtPojamZaPretragu.Text.Length > 0)
                    {
                        pocetnoVrijeme = DateTime.Now; //Cuvanje vremena prije pocetka pretrage

                        int ukupanBrojPonavljanja = 0;

                        for (int i = 0; i < readText.Length; i++)
                        {
                            int brojPonavljanja = Regex.Matches(readText[i], txtPojamZaPretragu.Text).Count;
                            ukupanBrojPonavljanja += brojPonavljanja;
                            if (brojPonavljanja > 0)
                                logoviRtxt.Text += ">Broj ponavljanja u fajlu " + files[i].ToString() + ": " + brojPonavljanja + "\n"; //Ispis fajlova u kojima je pojam pronadjen na konzolu
                            logoviRtxt.ScrollToCaret();
                        }
                        logoviRtxt.Text += "------------------------------------------------------------------------------------\n";
                        txtUkupanBroj.Text = ukupanBrojPonavljanja.ToString();
                        txtVrijeme.Text = "" + (pocetnoVrijeme.Subtract(DateTime.Now).TotalSeconds * (-1)); //Ispis vremena potrebnog za pretragu
                    }
                    else
                    {
                        MessageBox.Show("Molimo Vas da unesete pojam za pretragu.", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                }
                else
                {
                    MessageBox.Show("Molimo Vas da odaberete folder sa fajlovima za pretragu.", "Obavještenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                txtUkupanBroj.Text = 0 + "";
                if (rbtnParalelno.Checked == true)
                {

                    if (readText != null)
                    {
                        if (txtPojamZaPretragu.Text.Length > 0)
                        {
                            pocetnoVrijeme = DateTime.Now;

                            int[] niz = new int[brojTredova];

                            for (int i = brojTredova, pocetniFajl = 0; i > 0; i--) //Podjela posla na broj tredova
                            {
                                int kraj = files.Length / (i);
                                //Svi parametri potrebni za pretragu su proslijedjeni putem konstruktora posto se metode u tredovima pozivaju bez parametara
                                ExThread obj = new ExThread(txtUkupanBroj, pocetnoVrijeme, txtVrijeme, readText, files, brojTredova, pocetniFajl, kraj, txtPojamZaPretragu.Text.ToString(), logoviRtxt, i);
                                Thread thr = new Thread(new ThreadStart(obj.pretraziTekst));
                                thr.Start();
                                pocetniFajl = files.Length  / (i);  //indeks početnog fajla
                            }
                        }
                        else
                        {
                            MessageBox.Show("Molimo Vas da unesete pojam za pretragu.", "Obavjest", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                    }
                    else
                    {
                        MessageBox.Show("Molimo Vas da odaberete folder sa fajlovima za pretragu.", "Obavjest", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }


        private void rbtnParalelno_MouseDown(object sender, MouseEventArgs e)
        {
            txtUkupanBroj.Text = 0 + "";
            txtVrijeme.Text = "0";

        }
       
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            logoviRtxt.Text = ">\n";
        }
    }


    public class ExThread //Kreiranje klase za rad sa tredovima (Moguce je bilo uraditi isto bez kreiranja nove klase ali radi citljivosti koda kreirali smo novu klasu)
    {
        string[] readText = null;
        string[] files = null;
        int brojTredova = 0;
        int pocetak, kraj, brojTreda;
        string pojamZaPretragu;

        static int trenutnoPrebrojano = 0;
        static int brojZavrsenih = 0;
        static string logovi = "";

        TextBox txtUkupanBroj;
        DateTime pocetnoVrijeme;
        TextBox txtVrijeme;
        RichTextBox logoviRtxt;
        public ExThread(TextBox txtUkupanBroj, DateTime pocetnoVrijeme, TextBox txtVrijeme, string[] readText, string[] files, int brojTredova, int pocetak, int kraj, string pojamZaPretragu, RichTextBox logoviRtxt, int brojTreda)
        {
            this.readText = readText;
            this.files = files;
            this.brojTredova = brojTredova;
            this.pocetak = pocetak;
            this.kraj = kraj;
            this.brojTreda = brojTreda;
            this.pojamZaPretragu = pojamZaPretragu;
            this.logoviRtxt = logoviRtxt;
            this.txtUkupanBroj = txtUkupanBroj;
            this.pocetnoVrijeme = pocetnoVrijeme;
            this.txtVrijeme = txtVrijeme;
            // this.parent = parent;

        }
        public void pretraziTekst()
        {
            int ukupanBrojPonavljanja = 0;
            

            for (int i = pocetak; i < kraj; i++)//Pretraga se vrsi na identican nacin kao sekvencijalno samo sa manjom kolicinom podataka
            {
                Console.WriteLine("Trenutni fajl: " + i);
                int brojPonavljanja = Regex.Matches(readText[i], pojamZaPretragu).Count;
                ukupanBrojPonavljanja += brojPonavljanja;
                if (brojPonavljanja > 0)
                    logovi += ">Broj ponavljanja u fajlu " + files[i].ToString() + ": " + brojPonavljanja + "\n";
            }

            brojZavrsenih++;
            trenutnoPrebrojano += ukupanBrojPonavljanja;
            if (brojZavrsenih == brojTredova)//Ukoliko su svi tredovi zavrsili svoj dio posla rezultati se ispisuju u polja koja su za to namjenjena
            {
                string text = trenutnoPrebrojano.ToString();
                txtUkupanBroj.Invoke(new Action(() => txtUkupanBroj.Text = text));
                brojZavrsenih = 0;
                trenutnoPrebrojano = 0;
                logoviRtxt.Invoke(new Action(() => logoviRtxt.Text += logovi));
                txtVrijeme.Invoke(new Action(() => txtVrijeme.Text = "" + (pocetnoVrijeme.Subtract(DateTime.Now).TotalSeconds * (-1))));
                logovi = "";
            }
            // Console.WriteLine(pocetnoVrijeme.ToString());
        }
    }
}
