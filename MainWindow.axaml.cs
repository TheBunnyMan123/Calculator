using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Input;
using org.matheval;

namespace Calculator;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    protected override void OnKeyDown(KeyEventArgs key) {
	Console.WriteLine("Key pressed: " + key.Key);
    	if (key.Key == Key.Enter) {
	    var eq = this.FindControl<TextBox>("MainTextBox").Text;
            var UserExpression = new Expression(eq);
            try {
                var ans = UserExpression.Eval();
                Console.WriteLine(ans);
                this.FindControl<TextBox>("MainTextBox").Text = ans.ToString();
            }catch {
                Console.WriteLine("Invalid Equation");
                var ans = "Err: " + eq;
                this.FindControl<TextBox>("MainTextBox").Text = ans.ToString();
            } 
	}
    }

    private void OnButtonClick(object sender, RoutedEventArgs EventArgs) {
        var source = EventArgs.Source as Control;
        if (source != null) {
            Console.WriteLine("Button: " + source.Name);
        
            switch(source.Name) {
                case "one":
                    this.FindControl<TextBox>("MainTextBox").Text = this.FindControl<TextBox>("MainTextBox").Text + "1";
                    break;
                case "two":
                    this.FindControl<TextBox>("MainTextBox").Text = this.FindControl<TextBox>("MainTextBox").Text + "2";
                    break;
                case "three":
                    this.FindControl<TextBox>("MainTextBox").Text = this.FindControl<TextBox>("MainTextBox").Text + "3";
                    break;
                case "four":
                    this.FindControl<TextBox>("MainTextBox").Text = this.FindControl<TextBox>("MainTextBox").Text + "4";
                    break;
                case "five":
                    this.FindControl<TextBox>("MainTextBox").Text = this.FindControl<TextBox>("MainTextBox").Text + "5";
                    break;
                case "six":
                    this.FindControl<TextBox>("MainTextBox").Text = this.FindControl<TextBox>("MainTextBox").Text + "6";
                    break;
                case "seven":
                    this.FindControl<TextBox>("MainTextBox").Text = this.FindControl<TextBox>("MainTextBox").Text + "7";
                    break;
                case "eight":
                    this.FindControl<TextBox>("MainTextBox").Text = this.FindControl<TextBox>("MainTextBox").Text + "8";
                    break;
                case "nine":
                    this.FindControl<TextBox>("MainTextBox").Text = this.FindControl<TextBox>("MainTextBox").Text + "9";
                    break;
                case "zero":
                    this.FindControl<TextBox>("MainTextBox").Text = this.FindControl<TextBox>("MainTextBox").Text + "0";
                    break;
                case "decimalpoint":
                    this.FindControl<TextBox>("MainTextBox").Text = this.FindControl<TextBox>("MainTextBox").Text + ".";
                    break;
                case "add":
                    this.FindControl<TextBox>("MainTextBox").Text = this.FindControl<TextBox>("MainTextBox").Text + "+";
                    break;
                case "subtract":
                    this.FindControl<TextBox>("MainTextBox").Text = this.FindControl<TextBox>("MainTextBox").Text + "-";
                    break;
                case "multiply":
                    this.FindControl<TextBox>("MainTextBox").Text = this.FindControl<TextBox>("MainTextBox").Text + "*";
                    break;
                case "divide":
                    this.FindControl<TextBox>("MainTextBox").Text = this.FindControl<TextBox>("MainTextBox").Text + "/";
                    break;
                case "exponent":
                    this.FindControl<TextBox>("MainTextBox").Text = this.FindControl<TextBox>("MainTextBox").Text + "^";
                    break;
                case "inparentheses":
                    this.FindControl<TextBox>("MainTextBox").Text = this.FindControl<TextBox>("MainTextBox").Text + "(";
                    break;
                case "outparentheses":
                    this.FindControl<TextBox>("MainTextBox").Text = this.FindControl<TextBox>("MainTextBox").Text + ")";
                    break;
                case "equals":
                    var eq = this.FindControl<TextBox>("MainTextBox").Text;
                    var UserExpression = new Expression(eq);
                    try {
                        var ans = UserExpression.Eval();
                        Console.WriteLine(ans);
                        this.FindControl<TextBox>("MainTextBox").Text = ans.ToString();
                        break;
                    }catch {
                        Console.WriteLine("Invalid Equation");
                        var ans = "Err: " + eq;
                        this.FindControl<TextBox>("MainTextBox").Text = ans.ToString();
                        break;
                    }
                case "clear":
                    this.FindControl<TextBox>("MainTextBox").Text = "";
                    break;
                default:
                    Console.WriteLine("Not a button(?)");
                    break;
        }
        }
    }
}
