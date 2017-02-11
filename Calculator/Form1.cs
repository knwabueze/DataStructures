using DataStructures.Collections;
using System;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{ 
    public partial class Form1 : Form
    {
        Queue<int> numberQueue;
        Queue<OperationType> operationQueue;
        Queue<int> currentNumberQueue;
        bool justAnswered;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numberQueue = new Queue<int>();
            operationQueue = new Queue<OperationType>();
            currentNumberQueue = new Queue<int>();

            main_label.Text = "0";
            equation_label.Text = "";

            justAnswered = false;
        }

        private void numberProccessing(object sender, EventArgs e)
        {
            if (justAnswered)
            {
                justAnswered = false;
                currentNumberQueue.Clear();
            }
            currentNumberQueue.Enqueue(int.Parse(((Button)sender).Text));
            main_label.Text = Utils.queueToBase(Queue<int>.Copy(currentNumberQueue), 10).ToString();

            updateTopLabel();
        }

        private void operationProccessing(object sender, EventArgs e)
        {
            justAnswered = false;
            Button newSender = (Button)sender;

            if (currentNumberQueue.Count != 0)
            {
                numberQueue.Enqueue(int.Parse(main_label.Text));
                currentNumberQueue.Clear();

                switch (newSender.Tag)
                {
                    case "plus":
                        operationQueue.Enqueue(OperationType.ADD);
                        break;
                    case "minus":
                        operationQueue.Enqueue(OperationType.SUBTRACT);
                        break;
                    case "times":
                        operationQueue.Enqueue(OperationType.MULTIPLY);
                        break;
                    case "divide":
                        operationQueue.Enqueue(OperationType.DIVIDE);
                        break;
                }
            }

            updateTopLabel();
            doCalculate();
        }

        private void doCalculate()
        {
            if (numberQueue.Count >= 2)
            {
                int currentNumber = numberQueue.Dequeue();

                while (numberQueue.Count != 0)
                {
                    switch (operationQueue.Dequeue())
                    {
                        case OperationType.ADD:
                            currentNumber += numberQueue.Dequeue();
                            break;
                        case OperationType.SUBTRACT:
                            currentNumber -= numberQueue.Dequeue();
                            break;
                        case OperationType.MULTIPLY:
                            currentNumber *= numberQueue.Dequeue();
                            break;
                        case OperationType.DIVIDE:
                            int tbd = numberQueue.Dequeue();

                            if (tbd == 0)
                            {
                                main_label.Text = "Result is undefined.";
                                break;
                            }

                            currentNumber /= tbd;
                            break;
                    }
                }

                if (main_label.Text != "Result is undefined.")
                {
                    main_label.Text = currentNumber.ToString();
                    Utils.numberToQueue(currentNumber, ref currentNumberQueue);

                    justAnswered = true;

                    numberQueue.Clear();
                    operationQueue.Clear();                    
                    updateTopLabel();
                }
            }
        }

        private void updateTopLabel()
        {
            Queue<int> copiedQueue = Queue<int>.Copy(numberQueue);
            Queue<OperationType> copiedTypeQueue = Queue<OperationType>.Copy(operationQueue);

            string stringInProc = "";
            
            while (copiedTypeQueue.Count > 0)
            {
                if (copiedQueue.Count != 0)
                    stringInProc += copiedQueue.Dequeue().ToString() + " ";

                OperationType type = copiedTypeQueue.Dequeue();

                switch (type)
                {
                    case OperationType.ADD:
                        stringInProc += "+ ";
                        break;
                    case OperationType.SUBTRACT:
                        stringInProc += "- ";
                        break;
                    case OperationType.MULTIPLY:
                        stringInProc += "* ";
                        break;
                    case OperationType.DIVIDE:
                        stringInProc += "/ ";
                        break;
                }

                if (currentNumberQueue.Count != 0)
                    stringInProc += main_label.Text;
            }

            equation_label.Text = stringInProc;
        }

        private void clearButtonClicked(object sender, EventArgs e)
        {
            main_label.Text = "0";
            equation_label.Text = "";

            numberQueue.Clear();
            currentNumberQueue.Clear();
            operationQueue.Clear();
        }
    }
}
