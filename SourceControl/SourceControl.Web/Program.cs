var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequireDigit= false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<IRepositoryService, RepositoryService>();
builder.Services.AddTransient<IIssueService, IssueService>();
builder.Services.AddTransient<IPullRequestService, PullRequestService>();
builder.Services.AddTransient<IExcelImportExportService, ExcelImportExportService>();
builder.Services.AddLogging(loggerBuilder =>
{
	loggerBuilder.AddConfiguration(builder.Configuration.GetSection("Logging"))
      .AddSerilog(new LoggerConfiguration()
        .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Error)
		.WriteTo
        .File("log-file.txt")
        .CreateLogger())
      .AddConsole();
	loggerBuilder.AddDebug();
});

var app = builder.Build();
app.PrepareDatabase();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=Repository}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
