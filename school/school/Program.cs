public double berekenOmtrekCirkel(double straal)
{
    double PI = 3.1415926535897931;
    double omtrek = 2 * PI * straal;
    return omtrek;
}

public double berekenOppervlakteCirkel(double straal)
{
    double PI = 3.1415926535897931;
    double oppervlakte = PI * straal * straal;
    return oppervlakte;
}

double straalCirkel1 = 5.3;
double omtrekCirkel1 = berekenOmtrekCirkel(straalCirkel1);
double oppervlakteCirkel1 = berekenOppervlakteCirkel(straalCirkel1);

Console.WriteLine("De omtrek van een cirkel met straal " + straalCirkel1 + " is " + omtrekCirkel1);
Console.WriteLine("De oppervlakte van een cirkel met straal " + straalCirkel1 + " is " + oppervlakteCirkel1);