public partial class MenuPanel : Form
    {
        public MenuPanel()
        {
            InitializeComponent();
        }

        //-----------------------------------Monthly Mortgage------------------------------------------------

        //input values
        double interestRate,
               MonthlyPayment,
               BeginofMb;

        // constants
        const double monthly = 12;

        // outputs
        double interestPaidForMonth,
               RedofPrinciple,
               EndofMb;

        public void getInput() // get inputs
        {
            interestRate = Convert.ToDouble(maskInterestRate.Text);
            MonthlyPayment = Convert.ToDouble(maskMonthlyPay.Text);
            BeginofMb = Convert.ToDouble(maskBegMonthBal.Text);

           
            interestRate /= 100; // convert it from percent to decimal

               
            
        }

        public void calculateData() // calculate using inputs and constants
        {
            

            interestPaidForMonth = Math.Round((BeginofMb * interestRate) / monthly, 2); // interest paid for the month

            RedofPrinciple = MonthlyPayment - interestPaidForMonth; // reduction fo principle

            EndofMb = BeginofMb - RedofPrinciple; // end of month balance
        }

        public void displayData() // display calculations on output
        {
            txtIntForMonth.Text = interestPaidForMonth.ToString("c");
            txtReducPrinciple.Text = RedofPrinciple.ToString("C");
            txtEndOfMonth.Text = EndofMb.ToString("C");
        }

       

        

        private void caffeineCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (panelMonthly.Visible == false)
            {
                panelRule.Visible = false;
                panelMonthly.Visible = true;
               

            }
            else
            if (panelMonthly.Visible == true)
            {
                panelRule.Visible = false;
            }


        }

        private void ruleOf72ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelRule.Visible == false)
            {
                panelMonthly.Visible = false;
                panelRule.Visible = true;
            }
            else
            if (panelRule.Visible == true)
            {
                panelMonthly.Visible = false;
            }

        }

        private void btnCalories_Click_1(object sender, EventArgs e)
        {

        }

        private void MenuPanel_Load(object sender, EventArgs e)
        {
            panelMonthly.Visible = true;
            panelRule.Visible = false;
            btnCalculateBalance.Enabled = false;
            btnCalculateData.Enabled = false;
            
           
        }

        private void maskInterestRate_MouseUp(object sender, MouseEventArgs e)
        {
            maskInterestRate.SelectionStart = 0;
        }

        private void maskMonthlyPay_MouseUp(object sender, MouseEventArgs e)
        {
            maskMonthlyPay.SelectionStart = 0;
        }

        private void maskInterestRate_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(maskInterestRate.Text, out interestRate) && double.TryParse(maskMonthlyPay.Text, out MonthlyPayment) && double.TryParse(maskBegMonthBal.Text, out BeginofMb))
            {
              
                    btnCalculateData.Enabled = true;
                
            }
            else
            {
                btnCalculateData.Enabled = false;
            }

            
        }

        private void btnCalculateData_Click(object sender, EventArgs e)
        {
            getInput();
            calculateData();
            displayData();
        }

        //---------------------------Credit Card----------------------------

        //inputs
        double oldBalance,
               charges,
               credits;

        //outputs
        double newBalance,
               minimumPayment;

        //const
        const double fixedPayment = 20;
           
       
        

        public void creditInput() //inputs for credit
            {
            oldBalance = Convert.ToDouble(maskOldBalance.Text); 
            charges = Convert.ToDouble(maskChanges.Text);
            credits = Convert.ToDouble(maskCredits.Text);
            }

        private void btnCalculateBalance_Click(object sender, EventArgs e)
        {
            creditInput();
            creditCalculations();
            creditDisplay();
        }

        public void creditCalculations() // calculations for credit
        {
            
            newBalance = (oldBalance * 1.015) + charges - credits; // new balance including the rate
            
            if (newBalance <= fixedPayment)
            {
                minimumPayment = newBalance;
            }
            else
            {
                minimumPayment = ((newBalance - fixedPayment) * .10) + 20; // $20 is the fixed payment for this credit card company, so you have to take away $20 from the new balance before performing the equation!
            }

        }

        public void creditDisplay() // display for credit
        {
            txtNewBalance.Text = newBalance.ToString("c");

            txtMinimumPayment.Text = minimumPayment.ToString("c");
        }


        private void maskCredits_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(maskCredits.Text, out credits ) && double.TryParse(maskOldBalance.Text, out oldBalance) && double.TryParse(maskChanges.Text, out charges))  // check for correct values
            {
                btnCalculateBalance.Enabled = true;
            }
            else
            {
                btnCalculateBalance.Enabled = false;
            }
        }

        private void maskBegMonthBal_MouseUp(object sender, MouseEventArgs e)
        {
            maskBegMonthBal.SelectionStart = 0;
        }

        private void maskOldBalance_MouseUp(object sender, MouseEventArgs e)
        {
            maskOldBalance.SelectionStart = 0;
        }

        private void maskChanges_MouseUp(object sender, MouseEventArgs e)
        {
            maskChanges.SelectionStart = 0;
        }

        private void maskCredits_MouseUp(object sender, MouseEventArgs e)
        {
            maskCredits.SelectionStart = 0;
        }
    }