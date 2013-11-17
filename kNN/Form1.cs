using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kNN
{
    public partial class frmMain : Form
    {
        string customerfile;//file to classify
        string trainfile;//train database

        int k = 0;
       
        int counter = 0;

        List <Customer> lCustomer = new List<Customer>() ;
        List<Customer> uCustomer = new List<Customer>();

        public frmMain()
        {
            InitializeComponent();

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;


            trainfile = "customer.txt";

            this.lblStatus.Visible = false;

            //read information in customer file
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(trainfile);

            while ((line = file.ReadLine()) != null)
            {
                string[] split = line.Split(' ');

                Customer cus = new Customer();

                cus.setName(split[0]);

                cus.setAge(Int32.Parse(split[1]));
                cus.setGender(Int32.Parse(split[2]));
                cus.setIncoming(Int32.Parse(split[3]));
                cus.setNumcard(Int32.Parse(split[4]));
                cus.setResponse(Int32.Parse(split[5]));

                lCustomer.Add(cus);

                counter = counter + 1;
            }

            file.Close();

            this.lblTotal.Text = "/ " + counter;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog cFile = new OpenFileDialog();//open file windows
            cFile.Filter = "classify customer file|*.txt";//filter only open .txt file

            cFile.ShowDialog();

            customerfile = cFile.FileName;
            this.txtFile.Text = cFile.FileName;//get path file


            //read data into unknown customerset
            //read information in customer file
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader( customerfile );

            while ((line = file.ReadLine()) != null)
            {
                string[] split = line.Split(' ');


                Customer cus = new Customer();

                cus.setName(split[0]);

                cus.setAge(Int32.Parse(split[1]));
                cus.setGender(Int32.Parse(split[2]));
                cus.setIncoming(Int32.Parse(split[3]));
                cus.setNumcard(Int32.Parse(split[4]));
                cus.setResponse(-1);

                uCustomer.Add(cus);
            }

            file.Close();

        }

        private void btnClassify_Click(object sender, EventArgs e)
        {
            //check k
            if (txtNumber.Text != "")
            {
                k = Int32.Parse(txtNumber.Text);
                if (k > counter)
                {
                    MessageBox.Show("k must less than total of training set database", "Warning");
                }
                else
                {
                    Algorithm alg = new Algorithm(k, lCustomer, uCustomer);
                    alg.runkNN();

                    List<Customer> ans = new List<Customer>();
                    ans = alg.getCustomerList();

                    for (int i = 0; i < ans.Count; i++)
                    {
                        insertRow(i, ans[i]);
                    }
                }//end else

            }//check k number input
            else
            {
                lblStatus.Visible = true;
                lblStatus.Text = "k is empty! k should be odd number";
            }
        }

        private void insertRow(int index, Customer cus)
        {
            index = index + 1;

            string[] row = new string[7];
            row[0] = index + "";
            row[1] = cus.getName();
            row[2] = cus.getAge() + "";
            row[3] = cus.getGender() + "";
            row[4] = cus.getIncoming() + "";
            row[5] = cus.getNumcard() + "";
            row[6] = cus.getResponse() + "";

            dataGrid.Rows.Add(row);

        }
    }
}
