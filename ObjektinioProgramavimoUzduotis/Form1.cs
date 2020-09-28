using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjektinioProgramavimoUzduotis
{
    public partial class Form1 : Form
    {
        BindingList<Preke> gridPr;
        BindingList<Preke> gridKreps;
        Krepselis Krps;
        Siunta Snta;

        public Form1()
        {
            InitializeComponent();
            gridPr = new BindingList<Preke>();
            gridKreps = new BindingList<Preke>();
            Krps = new Krepselis();
            Snta = new Siunta();

            LoadFromFile();
            DGVprekiuSarasas.DataSource = gridPr;
            DGVprekiuSarasas.Columns["Ilgis"].Visible = false;
            DGVprekiuSarasas.Columns["Plotis"].Visible = false;
            DGVprekiuSarasas.Columns["Aukstis"].Visible = false;
            DGVprekiuSarasas.ClearSelection();

            DGVKrepselis.DataSource = gridKreps;
            DGVKrepselis.Columns["Ilgis"].Visible = false;
            DGVKrepselis.Columns["Plotis"].Visible = false;
            DGVKrepselis.Columns["Aukstis"].Visible = false;
            DGVKrepselis.ClearSelection();
        }

        public void SaveToFile()
        {
            using (StreamWriter stream = new StreamWriter("prekes.txt"))
            {
                string output = JsonConvert.SerializeObject(gridPr);
                stream.WriteLine(output);
            }
        }
        public void LoadFromFile()
        {
            using (StreamReader stream = new StreamReader("prekes.txt"))
            {
                string input = stream.ReadLine();
                gridPr = (JsonConvert.DeserializeObject<BindingList<Preke>>(input));
            }
        }
        void RestartKrepseli()
        {

            LBprekiukiekis.Text = "0";
            LBsuma.Text = "0";
            LBsiuntimas.Text = "";
            CBpristatymas.SelectedIndex = -1;
            LBeur.Left = LBsuma.Location.X + LBsuma.Width;
            gridKreps.Clear();
            Krps = new Krepselis();

        }
        void ReactToChanges()
        {
            double suma = 0;
            int prekiu = 0;
            foreach (var item in gridKreps)
            {
                suma += item.Kaina * item.Kiekis;
                prekiu += item.Kiekis;
            }
            Krps.MoketinaSuma = suma;
            if (gridKreps.Count > 0)
            {
                LBsuma.Text = Krps.MoketinaSuma.ToString() + '+' + Snta.PristatymoKaina(gridKreps.ToList()).ToString() + "(siuntimas)";
            }
            else 
            {
                RestartKrepseli();
            }
            
            LBeur.Left = LBsuma.Location.X + LBsuma.Width;

            LBprekiukiekis.Text = prekiu.ToString();
        }

        private void BTpridetiPreke_Click(object sender, EventArgs e)
        {
            var rand = new Random();
            int id = rand.Next(9999, 99999);
            while (gridPr.Where(p=>p.ID==id).Count()>0)
            {
                id = rand.Next(9999, 99999);
            }
            
            DGVprekiuSarasas.DataSource = gridPr;
            gridPr.Add(new Preke {
                ID = id,
                Pavadinimas = TBpavad.Text,
                Kaina = Convert.ToDouble(TBkaina.Text),
                Ilgis = Convert.ToInt32(TBx.Text),
                Plotis = Convert.ToInt32(TBy.Text),
                Aukstis = Convert.ToInt32(TBz.Text),
                Kiekis = Convert.ToInt32(TBkiekis .Text)
            });

            SaveToFile();
            TBpavad.Text = "";
            TBkaina.Text= "";
            TBx.Text= "";
            TBy.Text= "";
            TBz.Text= "";
            TBkiekis.Text= "";

        }
        private void CBrodytiMatmenis_CheckStateChanged(object sender, EventArgs e)
        {
            if (!CBrodytiMatmenis.Checked)
            {
                DGVprekiuSarasas.Columns["Ilgis"].Visible = false;
                DGVprekiuSarasas.Columns["Plotis"].Visible = false;
                DGVprekiuSarasas.Columns["Aukstis"].Visible = false;
            }
            else
            {
                DGVprekiuSarasas.Columns["Ilgis"].Visible = true;
                DGVprekiuSarasas.Columns["Plotis"].Visible = true;
                DGVprekiuSarasas.Columns["Aukstis"].Visible = true;
            }
        }
        private void Form1_Deactivate(object sender, EventArgs e)
        {
            SaveToFile();
        }
        private void DGVprekiuSarasas_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip2.Show(DGVprekiuSarasas, MousePosition.X, MousePosition.Y);
            }
        }
        private void DGVprekiuSarasas_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int a = e.RowIndex;
            DGVprekiuSarasas.ClearSelection();
            DGVprekiuSarasas.Rows[a].Selected = true;
        }
        private void contextMenuStrip2_MouseClick(object sender, MouseEventArgs e)
        {
            groupBox4.Visible = false;
            LBprekiukiekis.Text = (Convert.ToInt32(LBprekiukiekis.Text) + 1).ToString();
            double kaina = (double)DGVprekiuSarasas.SelectedRows[0].Cells[2].Value;
            Krps.MoketinaSuma += kaina;

            Preke temp = (Preke)DGVprekiuSarasas.SelectedRows[0].DataBoundItem;
            Preke currentObject = new Preke();
            currentObject.Pavadinimas = temp.Pavadinimas;
            currentObject.Kaina = temp.Kaina;
            currentObject.Ilgis = temp.Ilgis;
            currentObject.Plotis = temp.Plotis;
            currentObject.Aukstis = temp.Aukstis;
            currentObject.Kiekis = 1;
            currentObject.ID = temp.ID;
            gridKreps.Add(currentObject);

            LBsuma.Text = Krps.MoketinaSuma.ToString();
            //Snta.SiuntaSkaiciavimas(gridKreps.ToList());
            LBsuma.Text = Krps.MoketinaSuma.ToString() + '+' + Snta.PristatymoKaina(gridKreps.ToList()).ToString() + "(siuntimas)";

            LBeur.Left = LBsuma.Location.X + LBsuma.Width;
        }
        private void DGVKrepselis_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                CMSkrepselis.Show(DGVKrepselis, MousePosition.X, MousePosition.Y);
            }
        }
        private void DGVKrepselis_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int a = e.RowIndex;
            DGVKrepselis.ClearSelection();
            DGVKrepselis.Rows[a].Selected = true;
        }        
        private void DGVKrepselis_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ReactToChanges();            
        }
        private void šalintiIšKrepšelioToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            DGVKrepselis.Rows.RemoveAt(DGVKrepselis.SelectedRows[0].Index);
            ReactToChanges();
        }
        private void CBpristatymas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Snta.PristatymoBudas = CBpristatymas.Text;
            LBsiuntimas.Text = CBpristatymas.Text;           
        }
        private void BTpatvirtintiUzsakyma_Click(object sender, EventArgs e)
        {
            if (DGVKrepselis.Rows.Count > 0)
            {
                if (CBpristatymas.Text != "")
                {
                    groupBox4.Visible = true;
                    LBpristat.Text = CBpristatymas.Text;
                    LBmatmen.Text = Snta.SiuntosMatmenys.GabaritaiX.ToString() + 'X' + Snta.SiuntosMatmenys.GabaritaiY.ToString() + 'X' + Snta.SiuntosMatmenys.GabaritaiZ.ToString();
                    LBdydis.Text = Snta.SiuntosDydis.ToString();
                    LBsiuntosKaina.Text = (Snta.PristatymoKaina(gridKreps.ToList())+Krps.MoketinaSuma).ToString()+" eur.";
                    foreach (var item in gridKreps)
                    {
                        var temp = gridPr.Where(p => p.ID == item.ID).First();
                        temp.Kiekis -= item.Kiekis;
                    }
                    DGVprekiuSarasas.Update();
                    DGVprekiuSarasas.Refresh();
                    RestartKrepseli();
                }
                else
                {
                    MessageBox.Show("Nepasirinktas pristatymo būdas");
                }
            }
            else 
            {
                MessageBox.Show("Krepšelis tuščias");
            }
            
            
        }

        
    }
}
