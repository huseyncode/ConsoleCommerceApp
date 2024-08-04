using Application.Services.Abstract;
using Core.Constants;
using Core.Entities.UserEntities;
using Core.Messages;
using Data;
using Data.UnitOfWork.Concrete;

namespace ConsoleCommerceApp;

public static class Program
{
    private static readonly AdminService _adminService;
    private static readonly CustomerService _customerService;
    private static readonly SellerService _sellerService;
    private static readonly UnitOfWork _unitOfWork;

    static Program()
    {
        _unitOfWork = new UnitOfWork();
        _sellerService = new SellerService(_unitOfWork);
        _adminService = new AdminService(_unitOfWork);
        _customerService = new CustomerService(_unitOfWork);
    }
    static void Main(string[] args)
    {
        DbInitilaizer.SeedData();
        while (true)
        {
        LoginInput:
            Console.WriteLine("-- Console Commerce App --");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Seller");
            Console.WriteLine("3. Customer");
            Console.WriteLine("0. Exit");
            Console.WriteLine("--------------------------");
            Console.Write("Please select your role: ");
            string select = Console.ReadLine();
            if (select == "1")
            {
                if (!_adminService.Login())
                {
                    goto LoginInput;
                }
                while (true)
                {
                AdminChooseInput: Messages.InputMessages("choose");

                    ShowAdminMenu();
                    string choiceInput = Console.ReadLine();
                    int choice;
                    bool issucceeded = int.TryParse(choiceInput, out choice);
                    if (issucceeded)
                    {
                        switch ((AdminOperations)choice)
                        {
                            case AdminOperations.Exit:
                                return;
                            case AdminOperations.GetAllSellers:
                                _adminService.GetAllSellers();
                                break;
                            case AdminOperations.GetAllCustomers:
                                _adminService.GetAllCustomers();
                                break;
                            case AdminOperations.CreateSeller:
                                _adminService.CreateSeller();
                                break;
                            case AdminOperations.CreateCustomer:
                                _adminService.CreateCustomer();
                                break;
                            case AdminOperations.DeleteSeller:
                                _adminService.DeleteSeller();
                                break;
                            case AdminOperations.DeleteCustomer:
                                _adminService.DeleteCustomer();
                                break;
                            case AdminOperations.CreateCategory:
                                _adminService.CreateCategory();
                                break;
                            case AdminOperations.OrdersByDesc:
                                _adminService.OrdersByDesc();
                                break;
                            case AdminOperations.OrdersBySeller:
                                _adminService.OrdersBySeller();
                                break;
                            case AdminOperations.OrdersByCustomer:
                                _adminService.OrdersByCustomer();
                                break;
                            case AdminOperations.GetOrdersByCreateDate:
                                _adminService.GetOrdersByCreateDate();
                                break;
                            default:
                                Console.WriteLine("Invalid choice");
                                break;
                        }
                    }
                    else
                    {
                        Messages.InvalidInputMeesages("choice");
                        goto AdminChooseInput;
                    }
                }
            }
            else if (select == "2")
            {
                while (true)
                {
                    ShowSellerMenu();
                    Console.WriteLine("Press any key to return to the main menu...");
                    Console.ReadKey();
                    break;
                }
            }
            else if (select == "3")
            {
                while (true)
                {
                    ShowCustomerMenu();
                    Console.WriteLine("Press any key to return to the main menu...");
                    Console.ReadKey();
                    break;
                }
            }
            else if (select == "0")
            {
                return;
            }
            else
            {
                Messages.InvalidInputMeesages("role");
                goto LoginInput;

            }
        }
        
    }
    private static void ShowSellerMenu()
    {
        Console.WriteLine("------ SELLER MENU ------");
        Console.WriteLine("1. View Your Products");
        Console.WriteLine("2. Add New Product");
        Console.WriteLine("3. Update Product");
        Console.WriteLine("4. Remove Product");
        Console.WriteLine("5. View Your Orders");
        Console.WriteLine("0. Exit");
        Console.WriteLine("-------------------------");
        Console.Write("Please select an option: ");
    }
    private static void ShowCustomerMenu()
    {
        Console.WriteLine("----- CUSTOMER MENU -----");
        Console.WriteLine("1. View Products");
        Console.WriteLine("2. View Categories");
        Console.WriteLine("3. Place Order");
        Console.WriteLine("4. View Your Orders");
        Console.WriteLine("5. Update Account");
        Console.WriteLine("0. Exit");
        Console.WriteLine("-------------------------");
        Console.Write("Please select an option: ");
    }


    private static void ShowAdminMenu()
    {
        Console.WriteLine("------ ADMIN MENU ------");
        Console.WriteLine("1. View All Sellers");
        Console.WriteLine("2. View All Customers");
        Console.WriteLine("3. Add New Seller");
        Console.WriteLine("4. Add New Customer");
        Console.WriteLine("5. Remove Seller");
        Console.WriteLine("6. Remove Customer");
        Console.WriteLine("7. Add New Category");
        Console.WriteLine("8. View Orders (Descending)");
        Console.WriteLine("9. View Orders by Seller");
        Console.WriteLine("10. View Orders by Customer");
        Console.WriteLine("11. View Orders by Creation Date");
        Console.WriteLine("0. Exit");
        Console.WriteLine("------------------------");
        Console.Write("Please select an option: ");
    }
}