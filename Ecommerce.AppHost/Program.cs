var builder = DistributedApplication.CreateBuilder(args);

var productApi = builder.AddProject<Projects.Ecommerce_ProductService>("Product-APIs");
var orderApi = builder.AddProject<Projects.Ecommerce_OrderService>("Order-APIs");
builder.AddProject<Projects.Ecommerce_Web>("webfrontend").WithReference(productApi).WithReference(orderApi);


builder.Build().Run();
