using System;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text;

namespace KR
{
    public partial class Input : Form
    {
        // (при скачивании заменить для работы с вашим сервером)
        private static String url = "http://localhost/scripts/KR/index.php"; 

        public Input()
        {
            InitializeComponent();
            // передача имен в cb
            String[] namesArr = GetFileNames().Split(':');
            files_cb.Items.AddRange(namesArr);
        }

        // возвращает массив доступных файлов
        private static String GetFileNames()
        {
            // пустой запрос
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            // сервер возвращает имена файлов через разделитель :
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            String namesStr = reader.ReadToEnd();
            response.Close();
            stream.Close();
            reader.Close();
            return namesStr;
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            // если файл не выбран
            if (files_cb.SelectedItem == null)
            {
                MessageBox.Show("Выберите файл.");
                return;
            }
                
            // содержимое файлов
            String[] textArr = getFilesContent(files_cb.SelectedItem.ToString());

            String inputStr, outputStr;
            if (textArr.Length == 0)
            {
                inputStr = outputStr = "";
            } else
            {
                inputStr = textArr[0];
                outputStr = textArr[1];
            }
            // вывод формы для отображения результата
            Output outputForm = new Output(inputStr, outputStr);
            outputForm.Show();
        }

        // возвращает содержимое входного и результирующего файлов
        private String[] getFilesContent(String fileNameStr)
        {
            // POST-запрос
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            
            // запись данных о выбранном пользователем файле
            String data = "fileName=" + fileNameStr;
            byte[] bytesOfData = Encoding.UTF8.GetBytes(data);

            request.ContentLength = bytesOfData.Length;
            request.ContentType = "application/x-www-form-urlencoded";

            Stream stream = request.GetRequestStream();
            stream.Write(bytesOfData, 0, bytesOfData.Length);
            stream.Close();

            // забираем из отклика два текста для вывода через разделитель ::
            WebResponse response = request.GetResponse();
            stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            String[] splitter = { "::" };
            String[] textArr = reader.ReadToEnd().Split(splitter, StringSplitOptions.RemoveEmptyEntries);
            response.Close();
            stream.Close();
            reader.Close();
            return textArr;
        }
    }
}
