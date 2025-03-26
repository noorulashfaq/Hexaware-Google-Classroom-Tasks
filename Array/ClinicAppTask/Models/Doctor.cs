
class Doctor
{
    public string Name { get; set; }
    public string Specialization { get; set; }
    public int Experience { get; set; }

    public override string ToString(){
        return $"Name: {Name}, Specialization: {Specialization}, Experience: {Experience} years\n";
    }
}
