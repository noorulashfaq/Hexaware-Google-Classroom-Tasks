class Patient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public int Age { get; set; }

	private static Patient _instance;


	public Patient(int id, string name, string phone, int age)
    {
        Id = id;
        Name = name;
        Phone = phone;
        Age = age;
    }

	public static Patient GetInstance(int id, string name, string phone, int age)
	{
		
		if (_instance == null){
			_instance = new Patient(id, name, phone, age);
			Console.WriteLine("Patient instance created.");
		}
		return _instance;
	}

	public override string ToString()
	{
		return $"Patient Details: ID={Id}, Name={Name}, Phone={Phone}, Age={Age}";
	}
}