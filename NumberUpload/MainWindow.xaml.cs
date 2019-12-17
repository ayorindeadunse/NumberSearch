using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;



namespace NumberUpload
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        
        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            processFile(string.Empty);                       
        }
        private List<tb_Setting> getFileLink()
        {
            try
            {
                using (ICN_NumberSearchEntities ctx = new ICN_NumberSearchEntities())
                {
                    return ctx.tb_Setting.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private void processFile(string filePath)
        {
            try
            {
                List<Operator> allOperators = getAllOperators();
                OpenFileDialog dlg = new OpenFileDialog();
                bool flag;
                if (!string.IsNullOrEmpty(filePath))
                {
                    flag = true;
                }
                else
                {
                    dlg.Title = "Select File";
                    dlg.Multiselect = false;
                    dlg.DefaultExt = ".csv";
                    dlg.Filter = "CSV Files|*.csv";
                    flag = (bool)dlg.ShowDialog();
                     filePath = dlg.FileName;
                }
                if (flag)
                {
                    txtUpload.Text = filePath;
                    System.IO.StreamReader sr = new System.IO.StreamReader(filePath);
                    List<NumberModel> nList = new List<NumberModel>();
                    List<NumberModel> errorList = new List<NumberModel>();
                    string ln = string.Empty;
                    int sn = 1;
                    do
                    {
                        ln = sr.ReadLine();
                        if (ln != null)
                        {
                            string[] lnk = ln.Split(',');
                            nList.Add(new NumberModel()
                            {
                                SN = sn++,
                                Number = lnk[2],
                                Operator = lnk[6],
                                //Extend database fields, include port completion time - updated by Ayorinde
                                port_completion_time = lnk[10]
                            });
                        }

                    }
                    while (ln != null);
                    if (nList != null)
                    {
                        List<NumberOperator> numbOpList = new List<NumberOperator>();
                        foreach (NumberModel n in nList)
                        {
                            int op_ID = getThisOperator(allOperators, n.Operator);
                            if (!string.IsNullOrEmpty(Convert.ToString(op_ID)))
                            {
                                long numberID = isNewNumber(n.Number);
                                if (numberID < 1)
                                {
                                    numberID = saveNewNumber(n.Number,n.port_completion_time);
                                }
                                numbOpList.Add(new NumberOperator { NumberID = numberID, OperatorID = op_ID });
                            }
                            else
                            {
                                errorList.Add(new NumberModel { Number = n.Number, Operator = n.Operator, SN = n.SN, Remark = "Operator Not Found" });
                            }
                        }
                        if (errorList.Count > 0)
                        {
                            dtgUpload.Visibility = Visibility.Visible;
                            dtgUpload.ItemsSource = nList;
                            txbStatus.Text = "File contains wrong data, File not uploaded.....";
                            txbStatus.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            if (numbOpList != null)
                            {
                                saveNumbers(numbOpList);
                                txbStatus.Text = "File uploaded successful.....";
                                txbStatus.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                //upload error 
                                txbStatus.Text="Upload Error.....";
                                txbStatus.Visibility = Visibility.Visible;
                            }
                        }
                        
                    }

                }
            }
            catch (Exception ex)
            {

            }  
        }

        private bool saveNumbers(List<NumberOperator> numberList)
        {
            try
            {
                using (ICN_NumberSearchEntities ctx = new ICN_NumberSearchEntities())
                {
                    foreach (NumberOperator nop in numberList)
                    {
                        ctx.AddObject("NumberOperators", nop);
                        ctx.SaveChanges();
                    }
                    
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private long isNewNumber(string number)
        {
            try
            {
                using(ICN_NumberSearchEntities ctx = new ICN_NumberSearchEntities())
                {
                    long thisNumber = ctx.Numbers.Where(n => n.Number1.Equals(number)).Select(i => i.NumberID).FirstOrDefault();
                    if (!string.IsNullOrEmpty(Convert.ToString(thisNumber)))
                    {
                       return thisNumber;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        private long saveNewNumber(string number, string port_complete_time)
        {
            try
            {
                using (ICN_NumberSearchEntities ctx = new ICN_NumberSearchEntities())
                {
                    Number numb = new Number();
                    numb.Number1 = number;
                    numb.port_completion_time = port_complete_time;
                    //include port completion time as well. Save it to database- Ayorinde.
                    //ctx.AddObject("Numbers", numb);
                    ctx.AddObject("Numbers", numb);
                    ctx.SaveChanges();
                    return numb.NumberID;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        private List<Operator> getAllOperators()
        {
            try
            {
                using (ICN_NumberSearchEntities ctx = new ICN_NumberSearchEntities())
                {
                    return ctx.Operators.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private int getThisOperator(List<Operator> allOperators, string operatorName)
        {
           return allOperators.Where(o => o.Name.Equals(operatorName)).Select(i=>i.OperatorID).FirstOrDefault();
        }
        private long saveUploadedFileName(string number)
        {
            try
            {
                using (ICN_NumberSearchEntities ctx = new ICN_NumberSearchEntities())
                {
                   // UploadedFiles numb = new UploadedFiles();
                   //numb.Number1 = number;
                  // ctx.AddObject("UploadedFiles", numb);
                   // ctx.SaveChanges();
                    //return numb.NumberID;

                    return 1;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //string filePath = getFileLink().Where(l => l.Name.Equals("UploadPath")).Select(i => i.Value).FirstOrDefault();
            //processFile(filePath);
        }
    }
    
}
public class NumberModel
{
    public int SN { get; set; }
    public string Number { get; set; }
    public string Operator { get; set; }
    public string Remark { get; set; }
    //include other fields

    public string port_completion_time { get; set; }
}
public class NumberOperatorModel
{
    public string NumberID { get; set; }
    public string OperatorID { get; set; }
}