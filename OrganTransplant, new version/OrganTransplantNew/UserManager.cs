namespace OrganTransplantNew;

public class UserManager
{
    string[] _firstNames = ["Kim", "Andrea", "Nikita", "Iben", "Dylan", "Charlie", "Alexis", "Sasha", "Kris","Nico"];
    string[] _lastNames = ["Thue", "Hansen", "Jensen", "Haraldsen", "Hagen", "Johnsen", "Chiesa"];
    string[] _bloodtypes = ["A+", "A-", "B+", "B-", "O+", "O-"];
    public List<UserParent> Users { get; private set; } = [];
    Random _random = new Random();
    public string Line { get; set; } = new string('_', 60);

    public UserManager()
    {
        UserParent.ResetCounter();
        RandomizePatients(_random);
        RandomizeDoctors(_random);
        CalculateSuccessRatePatient();
        CalculateSuccessRateDoctor();
    }

    public bool RandomizeBool(Random random)
    {
        return random.Next(0, 2) == 1;
    }

    public void RandomizePatients(Random random)
    {
        for (int i = 0; i < 30; i++)
        {
            string firstName = _firstNames[random.Next(_firstNames.Length)];
            string lastName = _lastNames[random.Next(_lastNames.Length)];
            string bloodType = _bloodtypes[random.Next(_bloodtypes.Length)];
            int age = random.Next(16, 80);
            string gender = random.Next(2) != 0 ? "Male" : "Female";
            bool isSmoker = RandomizeBool(random);
            bool isFat = RandomizeBool(random);
            bool isDiabetic = RandomizeBool(random);
            bool isAthletic = RandomizeBool(random);
            double successRate = 0;
            if (isAthletic)
            {
                isFat = false;
            }

            Users.Add(new Patient(firstName, lastName, age, Guid.NewGuid(), gender, successRate, bloodType, isSmoker,
                isFat, isDiabetic, isAthletic));
        }
    }

    public int GetValueIsSmoker(Patient match)
    {
        return match.IsSmoker ? -10 : 3;
    }

    public string ResponseIsSmoker(Patient patient, Random random)
    {
        string[] adjUnhealthy =
        [
            "is smoking a lot", "loves chainsmoking", "got yellow fingertips from the nicotine",
            "never miss an opportunity to smoke", $"is called 'Tar-{patient.LastName}' by friends"
        ];
        string[] adjHealthy =
        [
            "never smoked before", "hates smokes", "never had a cancer-stick before", "don't smoke", "got smokephobia"
        ];
        var i = random.Next(adjUnhealthy.Length);
        var i2 = random.Next(adjHealthy.Length);
        return patient.IsSmoker ? $"{patient.FirstName} {adjUnhealthy[i]}." : $"{patient.FirstName} {adjHealthy[i2]}.";
    }

    public int GetValueIsFat(Patient match)
    {
        return match.IsFat ? -10 : 3;
    }

    public string ResponseIsFat(Patient patient, Random random)
    {
        string[] adjUnhealthy =
        [
            "a bit overweight...", "a little chubby", "in love with sugartoots", "eating fried chicken everyday",
            "never passing up an opportunity to grab sweets"
        ];
        string[] adjHealthy =
        [
            "is keeping an strict diet", "is staying away from sugar", "avoiding fast food", "lost a lot of weight",
            "have been on Ozympic for a while now"
        ];
        var index = random.Next(adjUnhealthy.Length);
        var i2 = random.Next(adjHealthy.Length);
        return patient.IsFat
            ? $"{patient.FirstName} is {adjUnhealthy[index]}."
            : $"{patient.FirstName} is {adjHealthy[i2]}.";
    }

    public int GetValueIsDiabetic(Patient match)
    {
        return match.IsDiabetic ? -5 : 3;
    }

    public string ResponeIsDiabetic(Patient patient, Random random)
    {
        string[] diabetic =
        [
            "needs to monitor blood sugar regularly.", "has to be careful with their diet.",
            "is managing diabetes well.", "is struggling with blood sugar levels.",
            "has recently been diagnosed with diabetes."
        ];
        string[] nonDiabetic =
        [
            "doesn't have any issues with blood sugar.", "is living a healthy, diabetes-free life.",
            "enjoys sweets without worry.", "has no signs of diabetes.", "is perfectly healthy in terms of blood sugar."
        ];
        var index = random.Next(diabetic.Length);

        return patient.IsDiabetic
            ? $"{patient.FirstName} {diabetic[index]}"
            : $"{patient.FirstName} {nonDiabetic[index]}.";
    }

    public int GetValueIsAthletic(Patient match)
    {
        return match.IsAthletic ? 12 : 0;
    }

    public string ResponseIsAthletic(Patient patient, Random random)
    {
        string[] athletic =
        [
            "is in great shape and exercises regularly.", "loves running marathons and staying active.",
            "is a fitness enthusiast who goes to the gym daily.", "enjoys outdoor activities like hiking and cycling.",
            "has a passion for sports and staying fit."
        ];

        string[] nonAthletic =
        [
            "prefers a more relaxed lifestyle.", "doesn't engage much in physical activities.",
            "spends most time indoors and avoids exercise.", "isn't a fan of fitness routines.",
            "enjoys leisurely activities over sports."
        ];
        var index = random.Next(athletic.Length);
        return patient.IsAthletic
            ? $"{patient.FirstName} {athletic[index]}"
            : $"{patient.FirstName} {nonAthletic[index]}.";
    }

    public int GetValueAge(UserParent match)
    {
        var age = match.Age;
        if (match is Patient)
        {
            if (age < 30) return 10;
            if (age < 40) return 5;
            if (age < 50) return 3;
            if (age < 60) return -5;
            if (age < 70) return -8;
        }
        else if (match is Doctor)
        {
            if (age < 30) return 5;
            if (age < 40) return 7;
            if (age < 50) return 10;
            if (age < 60) return 8;
            if (age < 70) return 0;
        }

        return -10;
    }

    public void CalculateSuccessRatePatient()
    {
        foreach (var p in Users)
        {
            if (p is Patient patient)
            {
                var successChance = patient.GetSuccessRate();
                successChance += GetValueIsSmoker(patient);
                successChance += GetValueIsFat(patient);
                successChance += GetValueIsDiabetic(patient);
                successChance += GetValueIsAthletic(patient);
                successChance += GetValueAge(patient);
                successChance = Math.Clamp(successChance, 0, 100);
                patient.SetSuccessRate(successChance);
            }
        }
    }

    public void RandomizeDoctors(Random random)
    {
        for (int i = 0; i < 5; i++)
        {
            string firstName = _firstNames[random.Next(_firstNames.Length)];
            string lastName = _lastNames[random.Next(_lastNames.Length)];
            int age = random.Next(25, 72);
            string gender = random.Next(2) == 0 ? "Male" : "Female";
            int experience = random.Next(0, 40);
            bool isDrunk = RandomizeBool(random);
            bool isSloppy = RandomizeBool(random);
            bool isSharp = RandomizeBool(random);
            double successRate = 0;
            if (isSharp)
            {
                isSloppy = false;
            }

            Users.Add(new Doctor(firstName, lastName, age, Guid.NewGuid(), gender, successRate, experience, isDrunk,
                isSloppy, isSharp));
        }

        return;
    }

    public int GetValueisDrunk(Doctor match)
    {
        return match.IsDrunk ? -10 : 3;
    }

    public string ResponseIsDrunk(Doctor match)
    {
        string[] drunk =
        [
            "has had too much to drink and needs rest.", "is not in a condition to perform operations right now.",
            "shouldn't be allowed near patients at the moment.", "is clearly not sober and needs supervision.",
            "might need some time off to recover."
        ];
        string[] sober =
        [
            "is fully focused and ready to work.", "is in excellent condition to perform operations.",
            "is sharp and highly professional.", "is completely sober and reliable.",
            "is ready to handle any medical challenge."
        ];
        var i = _random.Next(_firstNames.Length);
        return match.IsDrunk ? $"{match.FirstName} {drunk[i]}" : $"{match.FirstName} {sober[i]}";
    }

    public int GetValueIsSharp(Doctor match)
    {
        return match.IsSharp ? 10 : 0;
    }

    public string ResponseIsSharp(Doctor match)
    {
        string[] sharp =
        [
            "is incredibly focused and precise in their work.", "shows exceptional attention to detail.",
            "is operating at the peak of their abilities.", "is making quick, accurate decisions under pressure.",
            "is in top form and performing brilliantly."
        ];

        string[] notSharp =
        [
            "seems a bit distracted and less focused than usual.", "is having trouble staying precise in their tasks.",
            "might need a break to regain focus.", "is not performing at their usual sharpness.",
            "seems to be struggling with maintaining accuracy."
        ];
        var i = _random.Next(sharp.Length);
        return match.IsSharp ? $"{match.FirstName} {notSharp[i]}" : $"{match.FirstName} {sharp[i]}";
    }

    public int GetValueIsSloppy(Doctor match)
    {
        return match.IsSloppy ? -7 : 3;
    }

    public string ResponseIsSloppy(Doctor match)
    {
        string[] sloppy =
        [
            "is careless and making mistakes.", "seems unorganized and messy during operations.",
            "isn't paying enough attention to detail.", "is rushing through tasks and making errors.",
            "needs to improve their precision and focus."
        ];

        string[] notSloppy =
        [
            "is meticulous and highly organized in their work.", "shows great attention to detail and precision.",
            "is performing tasks with exceptional care.", "is setting a high standard for professionalism.",
            "is demonstrating excellent focus and organization."
        ];
        var i = _random.Next(sloppy.Length);
        return match.IsSloppy ? $"{match.FirstName} {sloppy[i]}" : $"{match.FirstName} {notSloppy[i]}";
    }

    public int GetValueExpDoctor(Doctor match)
    {
        return match.Experience / 4;
    }

    public string ResponseIsExpDoctor(Doctor match)
    {
        string[] exp =
        [
            $"{match.Type} {match.LastName} is extremely experienced and has plenty of successful operations under their belt. They have been in the vocation for {match.Experience} years.",
            $"{match.Type} {match.LastName} is highly skilled and has substantial experience, with {match.Experience} years in the field.",
            $"{match.Type} {match.LastName} has a solid foundation of experience with {match.Experience} years as a doctor.",
            $"{match.Type} {match.LastName} is building their career with {match.Experience} years of experience and shows great promise.",
            $"{match.Type} {match.LastName} is a newer addition to the field with {match.Experience} years, but they are already making an impact."
        ];

        if (match.Experience >= 60)
        {
            return exp[0];
        }
        else if (match.Experience >= 30)
        {
            return exp[1];
        }
        else if (match.Experience >= 20)
        {
            return exp[2];
        }
        else if (match.Experience >= 10)
        {
            return exp[3];
        }
        else
        {
            return exp[4];
        }
    }


    public void CalculateSuccessRateDoctor()
    {
        foreach (var doc in Users)
        {
            if (doc is Doctor doctor)
            {
                var successChance = doc.GetSuccessRate();
                successChance += GetValueExpDoctor(doctor);
                successChance += GetValueAge(doctor);
                successChance += GetValueisDrunk(doctor);
                successChance += GetValueIsSloppy(doctor);
                successChance += GetValueIsSharp(doctor);
                successChance = Math.Clamp(successChance, 0, 100);
                doctor.SetSuccessRate(successChance);
            }
        }
    }

    public List<UserParent> GetUsers()
    {
        return Users;
    }

    public void ShowUsers(char input)
    {
        Console.Clear();
        if (input == '1')
        {
            Console.WriteLine("PATIENTS");
            Thread.Sleep(500);
            var sortedList = OrderByUserList();
            foreach (var user in sortedList)
            {
                if (user is Patient)
                {
                    user.ShowInfo();
                }
            }
        }
        else
        {
            Console.WriteLine("DOCTORS");
            Thread.Sleep(500);
            var sortedList = OrderByUserList();
            foreach (var user in sortedList)
            {
                if (user is Doctor doc)
                {
                    doc.ShowInfo();
                }
            }
        }
    }

    private List<UserParent> OrderByUserList()
    {
        var sortedList = Users.OrderBy(p => p.SuccessRate).ToList();
        return sortedList;
    }

    public void SelectPatient(char choice, SelectedUser selectedUser, OperationManager opManager,
        UserManager userManager)
    {
        Console.Clear();
        ShowUsers('1');
        Console.WriteLine("Select patient by ID // Tip: Copy and paste ID");
        var selected = Selected(userManager, selectedUser, opManager);
        if (selected is Patient patient)
        {
            if (choice == '1')
            {
                selectedUser.SetPatient1(patient);
            }
            else if (choice == '2')
            {
                if (selectedUser.GetPatient1() != null)
                {
                    Console.WriteLine("Finding donor...");
                    Thread.Sleep(500);
                    opManager.ShowPotentialMatches(userManager, selectedUser, opManager);

                    if (selected is Patient patient2)
                    {
                        selectedUser.SetPatient2(patient2);
                        Console.WriteLine($"{selectedUser.GetPatient2().FirstName} {selectedUser.GetPatient2().LastName}");
                        Console.WriteLine($"Donor selected: {patient2.FirstName} {patient2.LastName} ({patient2.BloodType})");
                    }
                    else
                    {
                        Console.WriteLine("No donor selected");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("You need to select 'patient 1' first...");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Invalid input 1 or 2");
                return;
            }

            Console.WriteLine($"{patient.FirstName} {patient.LastName} {patient.BloodType}");
        }
        else
        {
            Console.WriteLine("Invalid choice");
        }

        ShowAllSelectedUsers(selectedUser);
    }

    public void SelectDoctor(char choice, SelectedUser selectedUser, OperationManager operationManager,
        UserManager userManager)
    {
        ShowUsers('2');
        Console.WriteLine("Select doctor by ID // Tip: Copy and paste ID");
        var selected = Selected(userManager, selectedUser, operationManager);
        if (selected is Doctor doc)
        {
            selectedUser.SetDoctor(doc);
            Console.WriteLine($"Selected doctor: {doc.FirstName} {doc.LastName}");
        }

        ShowAllSelectedUsers(selectedUser);
    }

    public void ShowAllSelectedUsers(SelectedUser selectedUser)
    {
        Console.Clear();
        Console.WriteLine($"{Line}");
        Console.WriteLine("SELECTED USERS:");
        if (selectedUser.GetPatient1() != null)
        {
            if (selectedUser.GetPatient1() is Patient patient)
            {
                PatientInfoWithResponses(patient);
            }
        }
        else
            Console.WriteLine("Patient 1: Not selected");

        if (selectedUser.GetPatient2() != null)
            if (selectedUser.GetPatient2() is Patient patient)
            {
                PatientInfoWithResponses(patient);
            }
            else
                Console.WriteLine("Patient 2: Not selected");

        if (selectedUser.GetSelectedDoctor() != null)
            if (selectedUser.GetSelectedDoctor() is Doctor doctor)
            {
                DoctorInfoWithResponses(doctor);
            }
            else
                Console.WriteLine("Doctor: Not selected\n");

        Console.WriteLine($"{Line}\n");
    }

    public void DoctorInfoWithResponses(Doctor doctor)
    {
        Console.WriteLine("DOCTOR INFO:");
        Console.WriteLine($"FIRSTNAME:{doctor.FirstName}\nLASTNAME:{doctor.LastName}\nAGE:{doctor.Age}\nGENDER:{doctor.Gender}\nSUCCESS RATE:{doctor.SuccessRate}%\nEXPERIENCE:{doctor.Experience} years.\nNOTES:\n{ResponseIsDrunk(doctor)}\n{ResponseIsSloppy(doctor)}\n{ResponseIsSharp(doctor)}");
    }

    public void PatientInfoWithResponses(Patient patient)
    {
        Console.WriteLine($"{Line}");
        Console.WriteLine("PATIENT JOURNAL");
        Console.WriteLine(
            $"FIRSTNAME:{patient.FirstName}\nLASTNAME:{patient.LastName}\nAGE:{patient.Age}\nGENDER:{patient.Gender}\nBLOOD TYPE:{patient.BloodType}\nNOTES:\n{ResponseIsFat(patient, _random)}\n{ResponseIsSmoker(patient, _random)}\n{ResponeIsDiabetic(patient, _random)}\n{ResponseIsAthletic(patient, _random)}");
        Console.WriteLine($"{Line}\n");
    }

    public UserParent Selected(UserManager userManager, SelectedUser selectedUser, OperationManager operationManager)
    {
        while (true)
        {
            if (!Guid.TryParse(Console.ReadLine(), out var inputGuid))
            {
                Console.WriteLine("Invalid ID. Please try again.");
                continue;
            }

            var selected = userManager.Users.Find(user => user.GetId() == inputGuid);

            if (selected != null)
            {
                Console.WriteLine($"You have selected {selected.FirstName} {selected.LastName}");
                if (selectedUser.GetPatient1() != null)
                {
                    operationManager.ShowPotentialMatches(userManager, selectedUser, operationManager);
                }

                return selected;
            }

            Console.WriteLine("Invalid ID. Please try again.");
        }
    }
}