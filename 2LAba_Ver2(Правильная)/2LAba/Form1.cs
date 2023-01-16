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

namespace _2LAba
{
    
        public partial class Form1 : Form
        {
            private string sPath = string.Empty;
            string filename;
            string text;
            public Form1()
            {
                InitializeComponent();

                 sPath = Path.Combine(Application.StartupPath, "noted.txt");
                //Text = sPath;
                StreamReader reader = new StreamReader(sPath);
             
                text = reader.ReadToEnd();
            textBox1.Text = text;
        }

            private void button1_Click(object sender, EventArgs e)
            {

            literal.Clear();
            ideficatori.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView5.Rows.Clear();
            dataGridView6.Rows.Clear();
            dataGridView4.Rows.Clear();

            // асинхронное чтение
            //StreamReader reader = new StreamReader(sPath);


            //// получаем выбранный файл

            //string text = reader.ReadToEnd();


            ///////////////////////////////// textBox1.Text = text;

            text = textBox1.Text;



                string[] words = text.Split(new char[] { ' ' });

                dataGridView1.Columns.Add("column-1", "Лексема");
                dataGridView1.Columns.Add("column-1", "тип");

                string bufer = "";


                string bufer1 = ". = * :=  + ; : , \r \n"; // разрешенные массив допустимых разделителей  [= + := и т.д.] 3 разделителей не бывает
               


                string proga = text;



            bool breaeek = false; // чтоб в касе спец символа не вылетал  case false: 
            for (int y = 0; y < proga.Length; y++)
            {
                char sunvol = proga[y];

                switch (Char.IsNumber(sunvol))// цифра
                {
                    case true:
                        bufer += sunvol;
                        if (Char.IsNumber(proga[y + 1]))
                        {
                            continue;
                        }
                        else
                        {
                            if (Char.IsLetter(proga[y + 1]))// ||  Char.IsLetter(bufer[bufer.Length-1])==false) // ошибка имя называется на цифру(1swq)
                            {
                                MessageBox.Show("не  допустимое имя " + Convert.ToString(sunvol) + (proga[y + 1]));
                                y = proga.Length - 1;
                                dataGridView1.Rows.Clear();
                            }
                            else
                            {
                                dataGridView1.Rows.Add(bufer, 'D');
                                bufer = "";
                                continue;
                            }
                            continue;
                        }




                } 
                
                bool simVol(char yt)
                {
                    return true;
                }
                
                // Цифра
                switch (sunvol ==  Convert.ToChar(" ")) // пробел
                {
                    case true:

                        continue;


                } // пробел
                switch ((Char.IsLetter(sunvol))) // символ
                {
                    case true:
                        bufer += sunvol;
                        if (y + 1>proga.Length-1) // иначе ошибка дальше будет при вводе йцу
                        {
                            dataGridView1.Rows.Add(bufer, 'I');
                            breaeek = true;
                            break;
                        } 
                        if (Char.IsLetter(proga[y + 1]))
                        {
                            continue;
                        }
                        else
                        {
                            dataGridView1.Rows.Add(bufer, 'I'); // индификатор
                            bufer = "";
                            continue;
                        }


                }




                bool rr(char ee)
                {
                    if (bufer1.Contains(ee) && (Convert.ToString(ee) != "\r") && (Convert.ToString(ee) != "\n"))
                    {
                        //MessageBox.Show("Слово найдено");
                        return true;
                    }
                    else
                    {
                        //MessageBox.Show("Слова нет в заданом тексте");
                        return false;
                    }

                }
                switch (bufer1.Contains(sunvol)) // Спец символ
                {




                    //string[] bufer12 = bufer1.Split(new char[] { ' ' });
                    case true:
                        bufer += proga[y];

                        if ((y + 1) > proga.Length - 1)
                        {
                            if (rr(sunvol) == true)
                            {
                                dataGridView1.Rows.Add(bufer, 'R');
                                bufer = "";
                            }
                            continue;
                        }
                        else
                        {
                            if (Char.IsSymbol(proga[y + 1]))
                            {
                                bufer += proga[y + 1];
                                string[] bufer12 = bufer1.Split(new char[] { ' ' });
                                if (rr(sunvol) == true)
                                {
                                    dataGridView1.Rows.Add(bufer, 'R');
                                    bufer = "";
                                }

                                continue;
                            }
                            else
                            {

                                if (rr(sunvol) == true)
                                {
                                    dataGridView1.Rows.Add(bufer, 'R');
                                    bufer = "";

                                }
                                else                                   /////// для \r \n
                                {
                                    bufer = "";
                                }



                                continue;
                            }

                        }

                    case false:                      //  ошибка если нет сивола в нашем алфавите (спец символ #)

                        if (breaeek==true)
                        {
                            break;
                        }
                        MessageBox.Show("не допустимый символ " + Convert.ToString(sunvol) );// + Convert.ToString(y));
                        y = proga.Length - 1;
                        dataGridView1.Rows.Clear();
                        continue;
                }








                //string str = "non-numeric";

                //Console.WriteLine(Char.IsNumber('8'));      // Output: "True"
                //Console.WriteLine(Char.IsNumber(str, 3));	// Output: "False"

            }




        }


        /////////////////////////////////////////////////2 лаба/////////////////////////////////
        // https://metanit.com/sharp/tutorial/4.9.php Dictionary



        List<int> literal = new List<int>();
        List<string> razdelitel = new List<string>() { "+", "-", ":=","/", "*", ",", ":", ";", "." };
        List<string> ideficatori = new List<string>();
        List<string> kluchevie = new List<string>() { "var","for", "to", "do", "end", "begin", "integer" };

        Dictionary< string, peremennaya> table = new Dictionary< string, peremennaya>();
        List<peremennaya1> table1 = new List<peremennaya1>();

        class peremennaya
        {
            public int table;   // имя
            public int number;                     // возраст
            //public string name;


            public void Print()
            {
                Console.WriteLine($"Имя: {number}  Возраст: ");
            }
        }

        class peremennaya1
        {
            public int table;   // имя
            public int number;                     // возраст
            public string name;


            public void Print()
            {
                Console.WriteLine($"Имя: {number}  Возраст: ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
            {
                dataGridView2.Rows.Clear();
                dataGridView3.Rows.Clear();
                //string path = "note1.txt";
                // асинхронное чтение
                StreamReader reader = new StreamReader(sPath);


                // получаем выбранный файл

               // string text = reader.ReadToEnd();


              //  textBox1.Text = text;


            string text = textBox1.Text;

            string[] words = text.Split(new char[] { ' ' });

                ///

               

                for (int r = 0; r != kluchevie.Count; r++)
                {

                    dataGridView2.Rows.Add(kluchevie[r]);
                }
                for (int r = 0; r != razdelitel.Count; r++)
                {

                    dataGridView3.Rows.Add(razdelitel[r]);
                }




            }

           

        private void button3_Click(object sender, EventArgs e)
        {
            //peremennaya Tabl4 = new peremennaya();
            //string buferTablici;
            //dataGridView5.Rows.Add("five","six","seven","eight");
            dataGridView5.Rows.Clear();
            string proga = text;

            string bufer = "";

            string poisk(string tt)
            {
                string outChar = tt;
            //if (ideficatori.Contains(tt))
            //    {
            //        outChar = "";
            //    }
                if (literal.Contains(Convert.ToInt32(tt)))
                {
                    outChar = "";
                }

                return outChar;
            }

            for (int y = 0; y < proga.Length; y++)
            {
                char sunvol = proga[y];

                switch (Char.IsNumber(sunvol))// цифра
                {
                    case true:
                        bufer += sunvol;
                        if (Char.IsNumber(proga[y + 1]))
                        {
                            continue;
                        }
                        else
                        {
                            if (Char.IsLetter(proga[y + 1])) // ошибка имя называется на цифру(1swq)
                            {
                                MessageBox.Show("не  допустимое имя " + Convert.ToString(sunvol) + (proga[y + 1]));
                                y = proga.Length - 1;
                                dataGridView1.Rows.Clear();
                            }
                            else
                            {
                                 
                                if (poisk(bufer) != "")
                                {
                                    literal.Add(Convert.ToInt32(bufer));

                                    peremennaya1 Tabl4 = new peremennaya1(); // записываю всю инф в класс
                                    Tabl4.table = 4;
                                    Tabl4.number = literal.Count + 1;
                                    Tabl4.name = Convert.ToString(bufer);
                                    table1.Add(Tabl4);

                                    dataGridView6.Rows.Add(bufer);
                                    dataGridView5.Rows.Add(bufer, "(4," + (literal.Count + 1) + ")"); // TTC

                                }
                                
                                bufer = "";
                                continue;
                            }
                            continue;
                        }




                }

                
                bool TTC (string r) //////////////////// проверка наличия в таблице уже этого слова
                {
                    //List<string> reyyr = new List<string>();

                    //for (int i = 0; i < dataGridView5.RowCount-1; i++)
                    //{

                    //    reyyr.Add(dataGridView5.Rows[i].Cells[0].Value.ToString());
                    //    string s =dataGridView5.Rows[i].Cells[0].Value.ToString();
                    //       // dataGridView3.Rows.Add(s);
                    //}

                    //    if (reyyr.Contains(r))
                    //    {
                    //        return true;
                    //    }

                        return false;
                     
                }
                //// Цифра
                switch (sunvol == Convert.ToChar(" ")) // пробел
                {
                    case true:

                        continue;


                } // пробел
                switch ((Char.IsLetter(sunvol))) // символ
                {
                    case true:
                        bufer += sunvol;
                        if (Char.IsLetter(proga[y + 1]))
                        {
                            continue;
                        }
                        else
                        {
                            if(kluchevie.Contains(bufer) && TTC(bufer)== false )
                            {
                                peremennaya1 Tabl4 = new peremennaya1();
                                Tabl4.table = 1;
                                Tabl4.number = kluchevie.IndexOf(bufer) + 1;
                                Tabl4.name = Convert.ToString(bufer);
                                table1.Add(Tabl4);

                                dataGridView5.Rows.Add(bufer, "(1," + (kluchevie.IndexOf(bufer) + 1) + ")"); // TTC

                            }
                            //if (razdelitel.Contains(bufer) && TTC(bufer) == false )
                            //{
                            //    dataGridView5.Rows.Add(bufer, "(2," + (razdelitel.IndexOf(bufer)+1) + ")"); // TTC
                            //}
                           // if ((ideficatori.Contains(bufer) != true)  && (kluchevie.Contains(bufer)!=true) ) - изначально было
                                if ((kluchevie.Contains(bufer) != true))         //
                                {                                                //
                                if ((ideficatori.Contains(bufer) != true))       //
                                { ideficatori.Add(bufer);                        //
                                    dataGridView4.Rows.Add(bufer);                 // изменил на 6 лабе
                                }                                                //
                                    
                                

                                peremennaya1 Tabl4 = new peremennaya1();
                                Tabl4.table = 3;
                                Tabl4.number = ideficatori.Count;
                                Tabl4.name = Convert.ToString(bufer);
                                table1.Add(Tabl4);

                                dataGridView5.Rows.Add(bufer, "(3," + ideficatori.Count + ")"); // TTC
                            }
                           // dataGridView5.Rows.Add(y, "(" + bufer + ")"); // TTC
                            bufer = "";
                            continue;
                        }


                }




                bool rr(string ee)
                {
                    if (razdelitel.Contains(Convert.ToString(ee)) && (Convert.ToString(ee) != "\r") && (Convert.ToString(ee) != "\n"))
                    {
                        //MessageBox.Show("Слово найдено");
                        return true;
                    }
                    else
                    {
                        //MessageBox.Show("Слова нет в заданом тексте");
                        return false;
                    }

                }
                switch (razdelitel.Contains(Convert.ToString(sunvol))) // Спец символ
                {

                    //case true:
                    //    bufer += proga[y];
                    //    if (razdelitel.Contains(bufer) && TTC(bufer) == false)
                    //    {
                    //        dataGridView5.Rows.Add(bufer, "(2," + (razdelitel.IndexOf(bufer)+1) + ")"); // TTC
                    //        bufer = "";
                    //    }
                    //    bufer = "";
                    //    continue;


                      //  string[] bufer12 = bufer1.Split(new char[] { ' ' });
                        case true:
                            bufer += proga[y];
                                      if ((y + 1) > proga.Length - 1)
                {
                    if (rr(bufer) == true && TTC(bufer) == false) // stroka 506
                    {
                                peremennaya1 Tabl4 = new peremennaya1();
                                Tabl4.table = 2;
                                Tabl4.number = razdelitel.IndexOf(bufer) + 1;
                                Tabl4.name = Convert.ToString(bufer);
                                table1.Add(Tabl4);

                                dataGridView5.Rows.Add(bufer, "(2," + (razdelitel.IndexOf(bufer) + 1) + ")"); // TTC
                                bufer = "";
                    }
                    continue;
                }
                else
                {
                    if (Char.IsSymbol(proga[y + 1]))
                    {
                        bufer += proga[y + 1];
                                //string[] bufer12 = bufer1.Split(new char[] { ' ' });
                                if (rr(bufer) == true && TTC(bufer) == false)
                                {
                                    peremennaya1 Tabl4 = new peremennaya1();
                                    Tabl4.table = 2;
                                    Tabl4.number = razdelitel.IndexOf(bufer) + 1;
                                    Tabl4.name = Convert.ToString(bufer);
                                    table1.Add(Tabl4);

                                    dataGridView5.Rows.Add(bufer, "(2," + (razdelitel.IndexOf(bufer) + 1) + ")"); // TTC

                                    bufer = "";
                                }
                                else                          ///////////////////////// иначе будет в 3 таблице :=a
                                {
                                    bufer = "";
                                }

                        continue;
                    }
                    else
                    {

                        if (rr(bufer) == true && TTC(bufer) == false)
                        {
                                    peremennaya1 Tabl4 = new peremennaya1();
                                    Tabl4.table = 2;
                                    Tabl4.number = razdelitel.IndexOf(bufer) + 1;
                                    Tabl4.name = Convert.ToString(bufer);
                                    table1.Add(Tabl4);

                                    dataGridView5.Rows.Add(bufer, "(2," + (razdelitel.IndexOf(bufer) + 1) + ")"); // TTC
                                    bufer = "";

                        }
                        else                                   /////// для \r \n
                        {
                            bufer = "";
                        }



                        continue;
                    }

                }

                //        case false:                      //  ошибка если нет сивола в нашем алфавите (спец символ #)

                //            MessageBox.Show("не допустимый символ " + Convert.ToString(sunvol) + Convert.ToString(y));
                //y = proga.Length - 1;
                //dataGridView1.Rows.Clear();
                continue;
            }








                //string str = "non-numeric";

                //Console.WriteLine(Char.IsNumber('8'));      // Output: "True"
                //Console.WriteLine(Char.IsNumber(str, 3));	// Output: "False"

            }
            //foreach (var person in table1)
            //{
            //    textBox2.Text += $"  \t key: {person.name}   ";
            //}
            //textBox3.Text = Convert.ToString(dataGridView5[0, 0].Value);
        }

       


        
        ////////////6 лаба///////////////////
        int state = 0; //хранит номер текущего состояния.
                       //Для перехода в другое состояние выполняется действие GOSTATE.

        Stack<int> sostStack = new Stack<int>(); // При этом, всю последовательность  переходов нужно сохранять в отдельном стеке.
        Stack<string> stack = new Stack<string>(); //хранятся анализируемые символы.

        //Действие SDVIG помещает  очередной символ из таблицы лексем(ТСС) на вершину стека

        // В текущем примере в  качестве входного потока взят массив символов vhodStr[pos_vhod].

        //Действие SVERTKA соответствует операции свертки в решающей таблице. При
        // это необходимо указывать два параметра: число символов num и название
        //нетерминала neterm.

        //        Данное действие удаляет из стека указанное число символов
        //num и кладет на вершину название правила neterm

        //        При этом, необходимо в цепочке
        //переходов между состояниями, сохраненной в sostStack, также вернуться на num
        //состояний назад.
        int versh = 0;
        int pos_vhod = 1;
        int pos_sost = 0;
       //int state = 0;
       //public string[] stack;
       // public int[] sostStack = new int[30];
        public string[] vhodStr;
        bool iserror = true;
        public void SDVIG(string mm)
        {
            next++;
            //string u = SearcVtabl(mm);
            try
            {
               // if (stack.Peek()!= mm)
               // {
                    stack.Push(SearcVtabl(mm));
                if (stack.Peek() == ":=expr")
                { stack.Push(";"); }
                // MessageBox.Show("Ожидался другой знак после " + mm, "Ошибка");
                // }
                //stack.Push(SearcVtabl(mm));//хранятся анализируемые символы.
            }
            catch (Exception ex) { iserror = false; }
        }

        public void GOSTATE(int st)
        {
            sostStack.Push(st); //охраненной в sostStack, также вернуться на num
                                //состояний назад.
                                //state = st++;//хранит номер текущего состояния.
            state = st;//хранит номер текущего состояния.        }
        }
            public void SVERTKA(int num, string neterm)
        {
           // versh += num + 1;
           // string line = "";
            while (num != 0)
            {
                //string rr = stack.Peek();
                //if (rr != "neterm")
                //{
                    stack.Pop();
                    sostStack.Pop();
                //}
                //else {
                //    stack.Pop();
                //    sostStack.Pop();
                //    num = 0;
                //}

                num++;
            }
            if (sostStack.Count == 0) // когда стек пустой становится 
            {
                state = 0;
                   stack.Push(neterm);
            }
            else {
                state = sostStack.Peek();
                stack.Push(neterm);
            }
            //state = sostStack.Peek();
            //stack.Push(neterm);

          //  textBox3.Text = "";
            //foreach (var t in stack)
            //{
            //    textBox3.Text += t+" ";
            //}
        }
        // textBox3.Text = Convert.ToString(dataGridView5[0, 0].Value);
        int next = 0;
        //List<int> literal = new List<int>();
        //List<string> razdelitel = new List<string>() { "+", "-", ":=", "*", ",", ":", ";", "." };
        //List<string> ideficatori = new List<string>();
        //List<string> kluchevie = new List<string>() { "var", "for", "to", "do", "end", "begin", "integer" };

        public string SearcVtabl(string yy)
        {
            string ret = yy;
            string metka = Convert.ToString(dataGridView5[1, next].Value);
            string metka3 = Convert.ToString(dataGridView5[0, next].Value);
            metka = metka.Replace(")", "");
            metka = metka.Replace("(", "");
            string[] words = metka.Split(new char[] { ',' });
            int table= Convert.ToInt32(words[0]);
            int leksema = Convert.ToInt32(words[1]);
            switch (table)
            {
                case 1:
                    if (kluchevie.Contains(kluchevie[leksema-1]) == true) //  вернет  "var", "for", "to", "do", "end", "begin", "integer"
                    {
                        ret = kluchevie[leksema-1];

                        break;
                    }
                    //continue;
                    break; 
                case 2: // если razdelitel   //  вернет  "+", "-", ":=", "*", ",", ":", ";", "." 
                    if (razdelitel[leksema-1] == "+" || razdelitel[leksema-1] == "-" || razdelitel[leksema-1] == "/" || razdelitel[leksema-1] == "*")
                    {
                        next = next +1;
                        ret = "expr";
                        //ret = stack.Peek();
                        //stack.Pop();

                    }
                    // else if (stack.Peek() == "expr")
                    //{
                       
                    //    stack.Pop();
                    //    //stack.Push(":=");
                    //    ret = "expr";
                    //    //next++;
                    //}
                     else
                    {
                        //    string metka1 = Convert.ToString(dataGridView5[0, next++].Value);
                        //    //metka1 = metka1.Replace(")", "");
                        //    //metka1 = metka1.Replace("(", "");
                        //    //string[] words1 = metka1.Split(new char[] { ',' });
                        //    if (metka1 == ",")
                        //    {
                        //        ret = ",";
                        //        next++;                             //  проработать когда после var   будет a+b  например
                        //    }
                        //    else
                        //    { }

                        ret  = razdelitel[leksema-1];
                    }
                   
                    
                    break;
                case 3: // если ideficatori
                        // string metka1 = Convert.ToString(dataGridView5[0, next++].Value);
                        // //metka1 = metka1.Replace(")", "");
                        // //metka1 = metka1.Replace("(", "");
                        // //string[] words1 = metka1.Split(new char[] { ',' });
                        // if (metka1 == ",")
                        // {
                        //     ret = ",";
                        //     next++;                             //  проработать когда после var   будет a+b  например
                        // }
                        //else {

                    if (stack.Peek() == ":=")
                    {

                        ret = "expr";
                        next = next + 2;
                        break;
                    }
                    if (stack.Peek() == "id")  /// если булет непосредсвенно 2 ID подряд 
                    {

                        ret = "#";                        
                        break;
                    }
                    //else if (stack.Peek() == "expr")
                    //{

                    //    stack.Pop();
                    //    //stack.Push(":=");
                    //    ret = "expr";
                    //    next++;
                    //}
                    //else if (stack.Peek()== "<опер>" || stack.Peek() == "<блок опер.>")
                    //{
                    //    ret = stack.Peek();
                    //    stack.Pop();
                    //    //stack.Push(":=");

                    //}
                    else
                    {
                        ret = "id";
                    }
                        
                    //}
                   
                    // next++;
                    break;
                case 4: // если literal -цифры
                  

                        next = next + 2;
                        ret = "expr";
                        //ret = stack.Peek();
                        //stack.Pop();
                        break;
                    
                      
                    


                    if (stack.Peek() == "<присв.>")//|| stack.Peek() == ":= ")
                    {
                        ret = stack.Peek();
                        stack.Pop();
                        break;
                    }
                    else if (stack.Peek() == ":=")
                    {
                        ret = "expr";
                        break;
                    }
                    else if (stack.Peek() == "<опер>" || stack.Peek() == "<блок опер.>")
                    {
                        ret = stack.Peek();
                        stack.Pop();
                        //stack.Push(":=");
                        break;

                    }
                    else
                    {
                        stack.Pop();
                        ret = "expr";
                        break;
                    }
                  
            }

            return ret;


        }
            private void button4_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
            button2_Click(sender, e);
            button3_Click(sender, e);
            string proga = text;
            for (int y = 0; y < proga.Length; y++)
            {
                char sunvol = proga[y];



            }
            Search6();
        }
        public void Search6()
        {
            //stack.Push(Convert.ToString(dataGridView5[0, next].Value));
            stack.Push(Convert.ToString(dataGridView5[0, next].Value));
            string metka = Convert.ToString(dataGridView5[0, next].Value);
            while (iserror == true)
            {
                //string metka = "";
                //if (stack.Count == 0)
                //{ metka = ""; }                   
                //else { metka = stack.Peek(); }
               
                // string ff  = stack.Peek();
                switch (state)
                {
                    case 0:
                        //if (stack.Peek() != "<программа>" || stack.Peek() != " " || stack.Peek() != "var")
                        //{
                            
                        //    MessageBox.Show(0 + "  Ожидался другой знак а не " + stack.Peek(), "Ошибка");
                        //    iserror = false;
                        //    break;
                        //}

                        if (stack.Peek() == "<программа>") // доделай
                        {
                            MessageBox.Show("Ошибок не найденно ", "Ошибка");
                            iserror = false;
                            break;
                        }
                        else if (stack.Peek() == " ") SDVIG(" ");
                        else if (stack.Peek() == "var") GOSTATE(1);
                        else if (stack.Peek() != " " || stack.Peek() != "var")
                        {

                            MessageBox.Show(0 + "Ожидалось встретить  - var", "Ошибка");
                            iserror = false;
                            break;
                        }
                        break;
                    case 1:
                        //if (stack.Peek() != "var" || stack.Peek() != "<спис_опис>" || stack.Peek() != "<опис>"|| stack.Peek() != "id" || stack.Peek() != "<спис_перем>")
                     
                        if (stack.Peek() == "var") SDVIG("var");
                        else if (stack.Peek() == "<спис_опис>") GOSTATE(2);
                        else if (stack.Peek() == "<опис>") GOSTATE(3);
                        else if (stack.Peek() == "id") GOSTATE(5);
                        else if (stack.Peek() == "<спис_перем>") GOSTATE(4);
                        else if (stack.Peek() != "var" || stack.Peek() != "id")
                        {

                            MessageBox.Show(1 + "Ожидалось встретить  -  id  ", "Ошибка");
                            iserror = false;
                            break;
                        }
                        break;
                    case 2:
                        //if (stack.Peek() != "<спис_опис>" || stack.Peek() != "<спис_опис>" || stack.Peek() != "<опис>" || stack.Peek() != "id" || stack.Peek() != "<спис_перем>")
                        //{

                        //    MessageBox.Show("Ожидался другой знак а не " + stack.Peek(), "Ошибка");
                        //    break;
                        //}
                        if (stack.Peek() == "<спис_опис>") SDVIG("<спис_опис>");
                        else if (stack.Peek() == ";") GOSTATE(6);
                        else if (stack.Peek() != "var" || stack.Peek() != "id")
                        {

                            MessageBox.Show(2 + "Ожидалось встретить  -  ';' ", "Ошибка");
                            iserror = false;
                            break;
                        }

                        break;
                    case 3:
                        SVERTKA(-1, "<спис_опис>");
                        break;
                        ///////////////////////////////
                        case 4:
                            if (stack.Peek() == "<спис_перем>") SDVIG("<спис_перем>");
                            else if (stack.Peek() == ":") GOSTATE(12);
                            else if (stack.Peek() == ",") GOSTATE(13);
                        else if (stack.Peek() != ":" || stack.Peek() != ",")

                        {

                            MessageBox.Show(4 + "Ожидалось встретить  - ':' или ','   ", "Ошибка");
                            iserror = false;
                            break;
                        }
                        // else { iserror = false; break; }
                        break;
                        case 5:
                       // if (stack.Peek() == "id") SVERTKA(-1, "<спис_перем>");
                        SVERTKA(-1, "<спис_перем>");
                            //else if (stack.Peek() == "}") GOSTATE(70);
                            // else if (stack.Peek() == ";") GOSTATE(71);
                            
                            break;
                    case 6:
                        if (stack.Peek() == ";") SDVIG(";");
                        else if (stack.Peek() == "begin") GOSTATE(7);
                        else if (stack.Peek() == "<опис>") GOSTATE(12);
                        else if (stack.Peek() == "<спис_перем>") GOSTATE(4);
                        else if (stack.Peek() == "id") GOSTATE(5);
                        else if (stack.Peek() == "<спис_перем>") GOSTATE(4);
                        else if (stack.Peek() != ";" || stack.Peek() != "id")
                        {

                            MessageBox.Show(6 + "Ожидалось встретить  -  'id' или ';' или 'begin' ", "Ошибка");
                            iserror = false;
                            break;
                        }
                        break;
                    case 7:
                        if (stack.Peek() == "begin") SDVIG("begin");          // регитр кода
                        else if (stack.Peek() == "<опер>") GOSTATE(16);
                        else if (stack.Peek() == "<спис_опер>") GOSTATE(8);
                        else if (stack.Peek() == "<присв.>") GOSTATE(20);
                        else if (stack.Peek() == "<условн.>") GOSTATE(21);
                        else if (stack.Peek() == "for") GOSTATE(22);
                        else if (stack.Peek() == "id") GOSTATE(28);
                        else if (stack.Peek() != "begin" || stack.Peek() != "for" || stack.Peek() != "id")
                        {

                            MessageBox.Show(7 + "Ожидалось встретить  -   'for'  или 'id' или 'begin' ", "Ошибка");
                            iserror = false;
                            break;
                        }
                        break;
                    case 8:
                        if (stack.Peek() == "<спис_опер>") SDVIG("<спис_опер>");          // регитр кода
                        else if (stack.Peek() == ";") GOSTATE(9);
                        else if (stack.Peek() != ";")
                        {

                            MessageBox.Show(8 + "Ожидалось встретить  -   ';'  ", "Ошибка");
                            iserror = false;
                            break;
                        }
                        break;

                    case 9:
                        if (stack.Peek() == ";") SDVIG(";");          // регитр кода
                        else if (stack.Peek() == "end") GOSTATE(10);
                        else if (stack.Peek() == "<опер>") GOSTATE(18);
                        else if (stack.Peek() == "<присв.>") GOSTATE(20);
                        else if (stack.Peek() == "<условн.>") GOSTATE(21);
                        else if (stack.Peek() == "for") GOSTATE(22);
                        else if (stack.Peek() == "id") GOSTATE(28);
                        else if (stack.Peek() != "id" || stack.Peek() != "for" || stack.Peek() != "end" )
                        {

                            MessageBox.Show(9 + "Ожидалось встретить  -   'id' или'for' или 'end'  ", "Ошибка");
                            iserror = false;
                            break;
                        }
                        break;
                    case 10:
                        if (stack.Peek() == "end") SDVIG("end");          // регитр кода
                        else if (stack.Peek() == ".") GOSTATE(11);
                        else if (stack.Peek() != "."  )
                        {

                            MessageBox.Show(10 + "Ожидалось встретить  -   '.'   ", "Ошибка");
                            iserror = false;
                            break;
                        }
                        break;
                    case 11:
                        SVERTKA(-8, "<программа>");
                        break;
                    case 12:
                        if (stack.Peek() == ":") SDVIG(":");          // регитр кода
                        else if (stack.Peek() == "<тип>") GOSTATE(14);
                        else if (stack.Peek() == "integer") GOSTATE(30);
                        else if (stack.Peek() == "boolean") GOSTATE(31);
                        else if (stack.Peek() == "string") GOSTATE(32);
                        else if (stack.Peek() != "<тип>" || stack.Peek() != "integer" || stack.Peek() != "boolean" || stack.Peek() != "string")
                        {


                            MessageBox.Show(12 + "Ожидался другой знак а не " + Convert.ToString(dataGridView5[0, next].Value) + "", "Ошибка");
                            iserror = false;
                            break;
                        }
                        break;
                    case 13:
                        if (stack.Peek() == ",") SDVIG(",");          // регитр кода
                        else if (stack.Peek() == "id") GOSTATE(15);
                        else if (stack.Peek() != "id")
                        {


                            MessageBox.Show(13 + "Ожидался другой знак а не " + Convert.ToString(dataGridView5[0, next].Value) + "", "Ошибка");
                            iserror = false;
                            break;
                        }
                        break;
                    case 14:
                        SVERTKA(-3, "<опис>");
                        break;
                    case 15:
                        SVERTKA(-3, "<спис_перем>");
                        break;
                    case 16:
                        SVERTKA(-1, "<спис_опер>");
                        break;
                    case 18:
                        SVERTKA(-3, "<спис_опер>");
                        break;
                    case 20:
                        SVERTKA(-1, "<опер>");
                        break;
                    case 21:
                        SVERTKA(-1, "<опер>");
                        break;
                    case 22:
                        if (stack.Peek() == "for") SDVIG("for");
                        else if (stack.Peek() == "<присв.>") GOSTATE(23);
                        else if (stack.Peek() == "id") GOSTATE(28);
                        else if (stack.Peek() != "id")
                        {

                            MessageBox.Show(22 + "Ожидалось встретить  -  'id'  ", "Ошибка");
                            iserror = false;
                            break;
                        }
                        break;
                    case 23:
                        if (stack.Peek() == "<присв.>") SDVIG("<присв.>");
                        else if (stack.Peek() == "to") GOSTATE(24);
                        else if (stack.Peek() != "to")
                     
                        {

                            MessageBox.Show(23 + "Ожидалось встретить  -  'to'  ", "Ошибка");
                            iserror = false;
                            break;
                        }
                        break;
                    case 24:
                        if (stack.Peek() == "to") SDVIG("to");
                        else if (stack.Peek() == "<операнд>") GOSTATE(25);
                        else if (stack.Peek() == "id") GOSTATE(33);
                        else if (stack.Peek() == "lit") GOSTATE(34);
                        else if (stack.Peek() != "lit" || stack.Peek() != "id")
                        {

                            MessageBox.Show(24 + "Ожидалось встретить  -  'id'  ", "Ошибка");
                            iserror = false;
                            break;
                        }
                        break;
                    case 25:
                        if (stack.Peek() == "<операнд>") SDVIG("<операнд>");
                        else if (stack.Peek() == "do") GOSTATE(26);
                        else if (stack.Peek() == "id") GOSTATE(33);
                        else if (stack.Peek() == "lit") GOSTATE(34);
                        else if (stack.Peek() != "lit" || stack.Peek() != "id" || stack.Peek() != "lit")
                        {

                            MessageBox.Show(25 + "Ожидалось встретить  -  'do' или 'id'  ", "Ошибка");
                            iserror = false;
                            break;
                        }
                        break;
                       
                    case 26:
                        if (stack.Peek() == "do") SDVIG("do");
                        else if (stack.Peek() == "<блок опер.>") GOSTATE(27);
                        else if (stack.Peek() == "<опер>") GOSTATE(35);
                        else if (stack.Peek() == "begin") GOSTATE(37);
                        else if (stack.Peek() == "<присв.>") GOSTATE(20);
                        else if (stack.Peek() == "<условн.>") GOSTATE(21);
                        else if (stack.Peek() == "for") GOSTATE(22);
                        else if (stack.Peek() == "id") GOSTATE(28);
                        else if (stack.Peek() != "for" || stack.Peek() != "id" || stack.Peek() != "begin")
                        {

                            MessageBox.Show(26 + "Ожидалось встретить  -  'for' или 'id' или 'begin'  ", "Ошибка");
                            iserror = false;
                            break;
                        }
                        break;
                    case 27:
                        SVERTKA(-6, "<условн.>");
                        break;
                    case 28:
                        if (stack.Peek() == "id") SDVIG("id");
                        //else if (stack.Peek() == "expr") SVERTKA(-1, "<услов.>");
                        else if (stack.Peek() == ":=") GOSTATE(43);
                        else if (stack.Peek() != ":=" )
                        {

                            MessageBox.Show(28 + "Ожидалось встретить  -  ':='   ", "Ошибка");
                            iserror = false;
                            break;
                        }
                        break;
                    case 43:
                        if (stack.Peek() == ":=") SDVIG(":=");
                        //else if (stack.Peek() == "expr") SVERTKA(-1, "<услов.>");
                        else if (stack.Peek() == "expr") GOSTATE(29);

                        break;
                    case 29:                        
                         SVERTKA(-3, "<присв.>"); // так было бы правильно еслиб ты не ошибся в 28 состояние- SVERTKA(-4, "<присв.>");
                        break;
                    case 30:
                        SVERTKA(-1, "<тип>");
                        break;
                    case 31:
                        SVERTKA(-1, "<тип>");
                        break;
                    case 32:
                        SVERTKA(-1, "<тип>");
                        break;
                    case 33:
                        SVERTKA(-1, "<операнд>"); //id
                        break;
                    case 34:
                        SVERTKA(-1, "<операнд>"); // lit
                        break;
                    case 35:
                        SVERTKA(-1, "<блок опер.>"); //////////////////// 
                        break;
                    case 36:
                        SVERTKA(-2, "<блок опер.>"); // ;
                        break;
                    case 37:
                        if (stack.Peek() == "begin") SDVIG("begin");
                        else if (stack.Peek() == "<блок опер.>") GOSTATE(38);
                        else if (stack.Peek() == "<опер>") GOSTATE(35);
                        else if (stack.Peek() == "begin") GOSTATE(37);
                        else if (stack.Peek() == "<присв.>") GOSTATE(20);
                        else if (stack.Peek() == "<условн.>") GOSTATE(21);
                        else if (stack.Peek() == "for") GOSTATE(22);
                        else if (stack.Peek() == "id") GOSTATE(28);
                        else if (stack.Peek() != "begin" || stack.Peek() != "id" || stack.Peek() != "for")
                        {

                            MessageBox.Show(37 + "Ожидалось встретить  -  'begin'  или 'for' или  'id'   ", "Ошибка");
                            iserror = false;
                            break;
                        }
                        break;
                    case 38:
                        if (stack.Peek() == "<блок опер.>") SDVIG("<блок опер.>");
                        else if (stack.Peek() == ";") GOSTATE(39);
                        else if (stack.Peek() != ";")
                        
                        {

                            MessageBox.Show(38 + "Ожидалось встретить  -  ';' ", "Ошибка");
                            iserror = false;
                            break;
                        }
                        break;
                    case 39:
                        if (stack.Peek() == ";") SDVIG(";");
                        else if (stack.Peek() == "end") GOSTATE(40);
                        else if (stack.Peek() != "end")
                        {


                            MessageBox.Show(39 + "Ожидался end  а не " + Convert.ToString(dataGridView5[0, next].Value) + "", "Ошибка");
                            iserror = false;
                            break;
                        }
                        break;
                    case 40:
                        SVERTKA(-4, "<блок опер.>"); // ;

                        break;
                    case 41:
                        SVERTKA(-4, "<блок опер.>"); // ;
                        break;
                    case 42:
                        if (stack.Peek() == "begin") SDVIG("begin");
                        else if (stack.Peek() == "<опер>") GOSTATE(35);
                        else if (stack.Peek() == "begin") GOSTATE(37);
                        else if (stack.Peek() == "<присв.>") GOSTATE(20);
                        else if (stack.Peek() == "<условн.>") GOSTATE(21);                       
                        else if (stack.Peek() == "for") GOSTATE(22);
                        else if (stack.Peek() == "id") GOSTATE(28);
                        else if (stack.Peek() != "begin" || stack.Peek() != "id" || stack.Peek() != "for")
                         
                        {

                            MessageBox.Show(42 + "Ожидалось встретить  -  'begin'  или 'for' или  'id'   ", "Ошибка");
                            iserror = false;
                            break;
                        }
                        break;
                    
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    
}
