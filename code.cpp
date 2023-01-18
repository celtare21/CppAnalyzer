#include <iostream>
#include <cmath>
using namespace std;

// Function to add two numbers
double add(double num1, double num2)
{
    return num1 + num2;
}

// Function to subtract two numbers
double subtract(double num1, double num2)
{
    return num1 - num2;
}

// Function to multiply two numbers
double multiply(double num1, double num2)
{
    return num1 * num2;
}

// Function to divide two numbers
double divide(double num1, double num2)
{
    if (num2 == 0)
    {
        cout << "Error: Cannot divide by zero." << endl;
        return 0;
    }

    return num1 / num2;
}

// Function to calculate the square of a number
double square(double num)
{
    return num * num;
}

// Function to calculate the square root of a number
double square_root(double num)
{
    if (num < 0)
    {
        cout << "Error: Cannot calculate the square root of a negative number." << endl;
        return 0;
    }

    return sqrt(num);
}

// Function to calculate the power of a number
double power(double num, double exponent)
{
    return pow(num, exponent);
}

int main()
{
    double num1, num2;
    char operation;
    bool is_float = false;
    bool run_calculator = true;

    while (run_calculator)
    {
        // Ask the user if they want to perform calculations with floating point numbers
        cout << "Do you want to perform calculations with floating point numbers? (y/n): ";
        char choice;
        cin >> choice;
        if (choice == 'y' || choice == 'Y')
            is_float = true;

        // Display menu of options to the user
        cout << "Select an operation:" << endl;
        cout << "1. Addition" << endl;
        cout << "2. Subtraction" << endl;
        cout << "3. Multiplication" << endl;
        cout << "4. Division" << endl;
        cout << "5. Square" << endl;
        cout << "6. Square Root" << endl;
        cout << "7. Power" << endl;
        cout << "8. Exit" << endl;
        cin >> operation;

        // Get the numbers from the user
        if (operation != '8')
        {
            cout << "Enter the first number: ";
            if (is_float)
                cin >> num1;
            else
            {
                int temp;
                cin >> temp;
                num1 = temp;
            }

            if (operation != '5' && operation != '6')
            {
                cout << "Enter the second number: ";
                if (is_float)
                    cin >> num2;
                else
                {
                    int temp;
                    cin >> temp;
                    num2 = temp;
                }
            }
        }

        // Perform the appropriate calculation based on the operation entered
        switch (operation)
        {
            case '1':
                cout << num1 << " + " << num2 << " = " << add(num1, num2) << endl;
                break;
            case '2':
                cout << num1 << " - " << num2 << " = " << subtract(num1, num2) << endl;
                break;
            case '3':
                cout << num1 << " * " << num2 << " = " << multiply(num1, num2) << endl;
                break;
            case '4':
                cout << num1 << " / " << num2 << " = " << divide(num1, num2) << endl;
                break;
            case '5':
                cout << "Square of " << num1 << " = " << square(num1) << endl;
                break;
            case '6':
                cout << "Square root of " << num1 << " = " << square_root(num1) << endl;
                break;
            case '7':
                cout << num1 << " raised to the power of " << num2 << " = " << power(num1, num2) << endl;
                break;
            case '8':
                cout << "Exiting Calculator..." << endl;
                run_calculator = false;
                break;
            default:
                cout << "Error: Invalid selection. Please enter a valid option." << endl;
        }
    }

    return 0;
}