using SOLIDPrinciples.SrpExample;
using SOLIDPrinciples.OcpExample;
using SOLIDPrinciples.LspExample;
using SOLIDPrinciples.IspExample;
using SOLIDPrinciples.DipExample;


#region 1 - Single Responsibility Principle
#region Before SRP
//Blog blog = new Blog
//{
//    Id = 1,
//    Title = "Single Responsibility Principle Nedir?",
//    Content = "SRP, bir sınıfın sadece bir sorumluluğa sahip olması gerektiğini savunur."
//};

//blog.SaveBlogToDatabase();
//var slug = blog.GenerateSlug();
//Console.WriteLine($"Slug: {slug}");
//blog.SendEmail("test@test.com");
#endregion

#region After SRP
//Blog blog = new Blog
//{
//    Id = 1,
//    Title = "Single Responsibility Principle Nedir?",
//    Content = "SRP, bir sınıfın sadece bir sorumluluğa sahip olması gerektiğini savunur."
//};

//var repository = new BlogRepository();
//var blogService = new BlogService();
//var emailService = new SOLIDPrinciples.SrpExample.EmailService();

//repository.SaveToDatabase();

//    string slug = blogService.GenerateSlug(blog);
//Console.WriteLine($"Slug: {slug}");

//emailService.SendBlogByEmail(blog, "test@test.com");
#endregion
#endregion

#region 2 - Open/Closed Principle
#region Before OCP
//PaymentProcessor paymentProcessor = new PaymentProcessor();

//paymentProcessor.ProcessPayment("CreditCard");
//paymentProcessor.ProcessPayment("Cash");
//paymentProcessor.ProcessPayment("Crypto");
#endregion

#region After OCP
//PaymentProcessor paymentProcessor = new();

//paymentProcessor.ProcessPayment(new CreditCardPayment());
//paymentProcessor.ProcessPayment(new CashPayment());
//paymentProcessor.ProcessPayment(new CryptoPayment());
#endregion
#endregion

#region 3 - Liskov Substitution Principle
#region Before LSP
//Vehicle vehicle = new Car();

//vehicle.Drive();
//vehicle.Fly(); // Exception fırlatıcak çünkü arabalar uçamaz!

//vehicle = new Airplane();
//vehicle.Drive();
//vehicle.Fly();

#endregion
#region After LSP

//Vehicle vehicle1 = new Car();

//if (vehicle1 is IDrivable drivableVehicle1)
//{
//    drivableVehicle1.Drive();
//}

//if (vehicle1 is IFlyable flyableVehicle1)
//{
//    flyableVehicle1.Fly();
//}

//Vehicle vehicle2 = new Airplane();

//if (vehicle2 is IDrivable drivableVehicle2)
//{
//    drivableVehicle2.Drive();
//}

//if (vehicle2 is IFlyable flyableVehicle2)
//{
//    flyableVehicle2.Fly();
//}
#endregion
#endregion

#region 4 - Interface Segregation Principle

#region Before ISP
//IMachine coffeeMachine = new CoffeeMachine();
//coffeeMachine.Start();
//coffeeMachine.MakeCoffee();
//coffeeMachine.Stop();

//IMachine microwave = new MicrowaveMachine();
//microwave.Start();
//microwave.HeatFood();
//microwave.Stop();

//IMachine printer = new Printer();
//printer.Start();
//printer.PrintDocument();
//printer.Stop();
#endregion

#region After ISP
//IStartable coffeeMachine = new CoffeeMachine();
//coffeeMachine.Start();
//((ICoffeeMaker)coffeeMachine).MakeCoffee();
//coffeeMachine.Stop();

//IStartable printer = new Printer();
//printer.Start();
//((IPrinter)printer).PrintDocument();
//printer.Stop();

//IStartable microwave = new Microwave();
//microwave.Start();
//((IFoodHeater)microwave).HeatFood();
//microwave.Stop();
#endregion

#endregion

#region 5 - Dependency Inversion Principle
#region Before DIP

//var notification = new Notification();
//notification.Notify("Dependency Inversion Principle Nedir?");

#endregion

#region After DIP
//IMessageService dipEmailService = new SOLIDPrinciples.DipExample.EmailService();
//var notification = new Notification(dipEmailService);
//notification.Notify("Dependency Inversion Principle Nedir?");
#endregion

#endregion

