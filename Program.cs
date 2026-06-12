using System.Numerics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/romanskirman_gmail_com", (string? x, string? y) =>
{
    if (!BigInteger.TryParse(x, out var a) ||
        !BigInteger.TryParse(y, out var b))
    {
        return Results.Text("NaN", "text/plain");
    }

    if (a <= 0 || b <= 0)
    {
        return Results.Text("NaN", "text/plain");
    }

    BigInteger gcd = Gcd(a, b);
    BigInteger lcm = (a / gcd) * b;

    return Results.Text(lcm.ToString(), "text/plain");
});

app.Run();

static BigInteger Gcd(BigInteger a, BigInteger b)
{
    while (b != 0)
    {
        (a, b) = (b, a % b);
    }

    return BigInteger.Abs(a);
}