using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Business;
using Data;
using Data.Models;


namespace ConsolePresentation
{
    public class Display
    {
        private int closeOperationId = 6;

        private ParticipantBusiness participantBusiness;
        private TeamBusiness teamBusiness;
        private RobotBusiness robotBusiness;
        private CompetitionBusiness competitionBusiness;

        public Display()
        {
            ChooseMenu();
            //AfterRegistrationMenu();
        }
        public void Fill()
        {
            //CompetitionBusiness.FillTable();

        }

        private void ChooseMenu()
        {
            Console.WriteLine("Choose menu: Registration/Statistics/Judges Menu/Show Competitions\n-> For registration choose R. \n-> To see the statistics choose S. \n-> To enter the Judges menu press button J.\n-> To see all competitions, press C.");
            Console.WriteLine("PRESS 0 if you want to close the program");
            string choice = Console.ReadLine();
            choice = choice.ToUpper();
            Console.WriteLine(new string('-', 150));
            if (choice == "0")
                Environment.Exit(0);
            if (choice == "R")
            {
                Console.WriteLine("Welcome! Thank you for choosing to register!");
                Console.WriteLine("Firstly, you need to create a team.");
                Console.WriteLine();
                CreateTeam();
                Console.WriteLine("If you want to close the program, PRESS 0.");
                Console.WriteLine("If you want to return to the main menu, PRESS 1.");
                Console.WriteLine();

                Console.WriteLine("Choose command");
                int input = int.Parse(Console.ReadLine());
                if (input == 0)
                    return;
                else
                    if (input == 1)
                    ChooseMenu();
                else
                    if (input == 2)
                    ChangeMenu();
                else
                    if (input == 3)
                    CreateTeam();
            }
            else
            if (choice == "C")
            {
                Console.WriteLine("COMPETITIONS:");
                Console.WriteLine();
                ListAllCompetitions();
                Console.WriteLine(new string('-', 150));
            }
            else
            if (choice == "S")
            {
                //teamBusiness.OrderBy(x => x.Points);
            }
            else
            if (choice == "J")
            {
                //password
                Console.WriteLine("Welcome to the Judge's menu");
                Console.WriteLine();
                Console.WriteLine("1) Evaluate team's robot");
                Console.WriteLine("2) See all participants");
                Console.WriteLine("3) See all participants in a team");
                Console.WriteLine("4) See teams");
                Console.WriteLine("5) See robots");
                Console.WriteLine("6) View competitions");
                Console.WriteLine("7) View ranking");
                Console.WriteLine("8) View winners");
                Console.WriteLine("PRESS 0 if you want to quit.");
                JudgesMenu();
                // judge switch case
            }
            else
            {
                Console.WriteLine("You entered invalid menu! Try again later!");
                System.Media.SystemSounds.Hand.Play();
            }
        }
        private void Registration(Participant participant)
        {
            ParticipantBusiness participantBusiness = new ParticipantBusiness();
            Console.WriteLine("Please enter some information about the members of the team ");

            Console.Write("Enter name: ");
            participant.FirstName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter middle name: ");
            participant.MiddleName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter surname: ");
            participant.Surname = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter age: ");
            participant.Age = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Enter phone number: ");
            participant.TelNumber = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter email: ");
            participant.Email = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter country: ");
            participant.Country = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter city: ");
            participant.City = Console.ReadLine();
            Console.WriteLine();

            participantBusiness.Add(participant);
        }

        private void CreateRobot(Robot robot)
        {
            RobotBusiness robotBusiness = new RobotBusiness();
            Console.Write("Enter name: ");
            robot.RobotName = Console.ReadLine();
            robotBusiness.Add(robot);
        }

        private void CreateTeam()
        {
            CompetitionBusiness competitionBusiness = new CompetitionBusiness();
            TeamBusiness teamBusiness = new TeamBusiness();
            ParticipantBusiness participantBusiness = new ParticipantBusiness();
            Console.Write(new string('-', 18));
            Console.Write(" COMPETITIONS ");
            Console.Write(new string('-', 18));
            Console.WriteLine();
            Console.WriteLine("AVAILABLE COMPETITIONS:");
            ListAllCompetitions();
            Console.WriteLine();

            Console.Write("Choose competition by typing its ID: ");

            int id = int.Parse(Console.ReadLine());
            var competition = competitionBusiness.Get(id);
            while (competition == null)
            {
                Console.Write("Please enter valid competition Id: ");
                id = int.Parse(Console.ReadLine());
                competition = competitionBusiness.Get(id);
            }

            Console.Write(new string('-', 22));
            Console.Write(" TEAM ");
            Console.Write(new string('-', 22));

            Console.WriteLine();
            Team team = new Team();
            Console.Write("Enter a name for your team: ");
            team.TeamName = Console.ReadLine();
            Console.WriteLine();

            Console.Write(new string('-', 22));
            Console.Write(" ROBOT ");
            Console.Write(new string('-', 21));

            Console.WriteLine();
            Console.WriteLine("Enter information for your robot");
            Console.WriteLine();

            RobotBusiness robotBusiness = new RobotBusiness();
            Robot robot = new Robot();
            try
            {
                CreateRobot(robot);
                //robotBusiness.Add(robot);
            }
            catch
            {
                Console.WriteLine("Unsuccessful registration!");
                Environment.Exit(0);
            }
            
            Console.Write(new string('-', 18));
            Console.Write(" PARTICIPANTS ");
            Console.Write(new string('-', 18));
            Console.WriteLine();
            Console.Write("Enter the number of participants: ");
            team.Number = int.Parse(Console.ReadLine());
            Console.WriteLine();

            team.RobotId = robot.RobotId;
            teamBusiness.Add(team);
            robot.TeamId = team.TeamId;
            robotBusiness.Update(robot);

            Console.WriteLine("Give some information about the participants");
            try
            {
                for (int i = 0; i < team.Number; i++)
                {
                    Participant participant = new Participant();
                    participant.TeamId = team.TeamId;
                    participant.RobotId = robot.RobotId;
                    participant.CompetitionId = competition.Id;
                    Registration(participant);
                    competitionBusiness.AddParticipantsInCompetiton(competition, participant);
                    Console.WriteLine();
                }
            }
            catch
            {
                Console.WriteLine("Unsuccessful registration!");
                teamBusiness.Delete(team.TeamId);
                robotBusiness.Delete(robot.RobotId);
                Environment.Exit(0);
            }

            //------------------------------------------------------------------
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"You successfully created team: #{team.TeamId} {team.TeamName.ToUpper()} with robot: #{robot.RobotId} {robot.RobotName.ToUpper()} and participants: ");
            ListAllParticipantsInTeam(team.TeamId);
            Console.WriteLine();
            Console.WriteLine("Congratulations and good luck!");

            AfterRegistrationMenu();
            Console.WriteLine("Thank you for your registration!\n");
        }
        private void AfterRegistrationMenu()
        {
            Console.WriteLine();
            Console.WriteLine("If you want to close the program, PRESS 0.");
            Console.WriteLine("If you want to return to the main menu, PRESS 1.");
            Console.WriteLine("If you want to return to change your registration, PRESS 2.");
            Console.WriteLine("If you want to make a new registration, PRESS 3.");

            int command = int.Parse(Console.ReadLine());
            switch (command)
            {
                case 0:
                    Environment.Exit(0); break;
                case 1:
                    ChooseMenu();
                    break;
                case 2:
                    ChangeMenu();
                    break;
                case 3:
                    CreateTeam();
                    break;
            }
        }

        //-----------------------------------------------------------------------
        private void ChangeMenu()
        {

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Here you can change whatever you want");
            Console.WriteLine("* However, if you do not want to change anything, PRESS 0.\n* If you want to return to the main menu, PRESS 1.");
            Console.WriteLine("* If you want to change information about the team, PRESS 2.\n* If you want to change information about a member of the team, PRESS 3.\n* If you want to change information about the robot, PRESS 4.");

            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 0:
                    Environment.Exit(0); ; break;
                case 1:
                    ChooseMenu(); break;
                case 2:
                    TeamChange(); break;
                case 3:
                    ParticipantChange(); break;
                case 4: RobotChange(); break;
                default: break;
            }


        }
        private void ParticipantChange()
        {
            TeamBusiness teamBusiness = new TeamBusiness();
            Console.WriteLine("Enter the ID of your team: ");
            int teamId = int.Parse(Console.ReadLine());
            var team = teamBusiness.Get(teamId);
            while (team == null)
            {
                Console.WriteLine("Team not found!");
                Console.Write("Please enter valid team ID: ");
                teamId = int.Parse(Console.ReadLine());
                team = teamBusiness.Get(teamId);
            }
            Console.WriteLine("If you want to quit, PRESS 0.");
            Console.WriteLine("If you want to update information about a participant, PRESS 1.");
            Console.WriteLine("If you want to delete a participant, PRESS 2.");
            Console.WriteLine("If you want to add a participant, PRESS 3");

            int operation = int.Parse(Console.ReadLine());
            switch (operation)
            {
                case 0:
                    Environment.Exit(0); break;
                case 1:
                    UpdateParticipant(teamId);
                    break;
                case 2:
                    DeleteParticipant(teamId);
                    team.Number = team.Number - 1;
                    teamBusiness.Update(team);
                    break;
                case 3:
                    Participant participant = new Participant();
                    Registration(participant);
                    participant.TeamId = team.TeamId;
                    participant.RobotId = team.RobotId;
                    //participant.CompetitionId
                    team.Number = team.Number + 1;
                    teamBusiness.Update(team);
                    participantBusiness.Update(participant);
                    break;
                default:
                    break;
            }
        }

        private void TeamChange()
        {
            Console.WriteLine("If you want to quit, PRESS 0.");
            Console.WriteLine("If you want to update information about the team, PRESS 1.");
            Console.WriteLine("If you want to delete the team, PRESS 2.");
            int operation = int.Parse(Console.ReadLine());
            switch (operation)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    UpdateTeam();
                    break;
                case 2:
                    DeleteTeam();

                    break;
                default:
                    break;
            }
        }

        private void RobotChange()
        {
            bool exit = false;
            Console.WriteLine("If you want to quit, PRESS 0.");
            Console.WriteLine("If you want to update information about a robot, PRESS 1.");
            Console.WriteLine("If you want to delete a robot, PRESS 2.");
            do
            {
                int operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 0:
                        exit = true; break;
                    case 1:
                        UpdateRobot();
                        break;
                    case 2:
                        DeleteRobot();
                        break;
                    default:
                        break;
                }
            } while (!exit);
        }
        //------------------------------------------------------------------------
        //ParticipantUpdates
        private void UpdateParticipant(int id)
        {
            ParticipantBusiness participantBusiness = new ParticipantBusiness();
            Console.WriteLine("Enter the ID of your freshly registrated team");
            Console.WriteLine("These are the participants in the team.");
            ListAllParticipantsInTeam(id);
            Console.WriteLine();
            Console.WriteLine("Enter participant's ID to update: ");
            int participantId = int.Parse(Console.ReadLine());
            Participant participant = participantBusiness.Get(participantId);
            Console.WriteLine();
            Console.WriteLine("What do you want to change?\nName/Middle name/Surname/Age/Phone number/Email/Country/City\nChoose one of the options.");
            string change = Console.ReadLine();
            change.ToLower();
            while (participant == null)
            {
                Console.WriteLine("Participant not found!");
                Console.Write("Please enter valid participant ID: ");
                id = int.Parse(Console.ReadLine());
                participant = participantBusiness.Get(id);
            }

            switch (change)
            {
                case "name": participant.FirstName = Console.ReadLine(); break;
                case "middle name": participant.MiddleName = Console.ReadLine(); break;
                case "surname": participant.Surname = Console.ReadLine(); break;
                case "age": participant.Age = int.Parse(Console.ReadLine()); break;
                case "phone number": participant.TelNumber = Console.ReadLine(); break;
                case "email": participant.Email = Console.ReadLine(); break;
                case "country": participant.Country = Console.ReadLine(); break;
                case "city": participant.City = Console.ReadLine(); break;
                default: break;
            }
            Console.WriteLine("Update successful");
            Console.WriteLine("ID: #{0} | Name: {1} {2} {3} | Age: {4} | Phone number: {5} | Email: {6} | Country: {7} | City: {8}", participant.ParticipantId, participant.FirstName, participant.MiddleName, participant.Surname, participant.Age, participant.TelNumber, participant.Email, participant.Country, participant.City);
            participantBusiness.Update(participant);
        }
        private void DeleteParticipant(int id)
        {
            ParticipantBusiness participantBusiness = new ParticipantBusiness();
            Console.WriteLine("Enter the id of your team");
            ListAllParticipantsInTeam(id);
            try
            {
                Console.WriteLine("Enter ID to delete: ");
                int participantId = int.Parse(Console.ReadLine());
                var participant = participantBusiness.Get(participantId);
                while (participant == null)
                {
                    Console.WriteLine("Participant not found!");
                    Console.Write("Please enter valid participant ID: ");
                    id = int.Parse(Console.ReadLine());
                    participant = participantBusiness.Get(id);
                }
                participantBusiness.Delete(participantId);
                Console.WriteLine("Successful operation");
                ListAllParticipantsInTeam(id);
            }
            catch (Exception)
            {
                Console.WriteLine("Unsuccessful operation");
            }

        }
        private void ListAllParticipants() //for competitions
        {
            ParticipantBusiness participantBusiness = new ParticipantBusiness();
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "PARTICIPANTS" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var participants = participantBusiness.GetAll();
            if (participants != null)
            {
                foreach (var p in participants)
                {
                    Console.WriteLine("ID: #{0} | Name: {1} {2} {3} | Age: {4} | Phone number: {5} | Email: {6} | Country: {7} | City: {8}\n", p.ParticipantId, p.FirstName, p.MiddleName, p.Surname, p.Age, p.TelNumber, p.Email, p.Country, p.City);
                }
            }
        }

        private void ListAllParticipantsInTeam(int id)
        {
            ParticipantBusiness participantBusiness = new ParticipantBusiness();
            TeamBusiness teamBusiness = new TeamBusiness();
            Team team = teamBusiness.Get(id);
            if (team != null)
            {
                foreach (var p in participantBusiness.GetAll())
                {
                    if (p.TeamId == id)
                        Console.WriteLine("ID: #{0} | Name: {1} {2} {3} | Age: {4} | Phone number: {5} | Email: {6} | Country: {7} | City: {8}", p.ParticipantId, p.FirstName, p.MiddleName, p.Surname, p.Age, p.TelNumber, p.Email, p.Country, p.City);
                }
            }
        }
        private void RemoveAllParticipantsFromTeam(int id)
        {
            ParticipantBusiness participantBusiness = new ParticipantBusiness();
            TeamBusiness teamBusiness = new TeamBusiness();
            Team team = teamBusiness.Get(id);
            if (team != null)
            {
                foreach (var p in participantBusiness.GetAll())
                {
                    if (p.TeamId == id)
                        participantBusiness.Delete(p.ParticipantId);
                }
            }
        }

        //--------------------------------------------------------------
        //TeamUpdates
        private void UpdateTeam()
        {
            TeamBusiness teamBusiness = new TeamBusiness();
            Console.WriteLine("Enter team ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Team team = teamBusiness.Get(id);

            while (team == null)
            {
                Console.WriteLine("Team not found!");
                Console.Write("Please enter valid team ID: ");
                id = int.Parse(Console.ReadLine());
                team = teamBusiness.Get(id);
            }

            Console.WriteLine("Write the new name: ");
            string name = Console.ReadLine();
            team.TeamName = name;

            teamBusiness.Update(team);
            Console.WriteLine("Update successful");
            AfterRegistrationMenu();
        }

        private void DeleteTeam()
        {
            TeamBusiness teamBusiness = new TeamBusiness();
            RobotBusiness robotBusiness = new RobotBusiness();

            //try
            //{
            Console.WriteLine("Enter ID to delete: ");
            int teamId = int.Parse(Console.ReadLine());
            var team = teamBusiness.Get(teamId);
            while (team == null)
            {
                Console.WriteLine("Team not found!");
                Console.Write("Please enter valid team ID: ");
                teamId = int.Parse(Console.ReadLine());
                team = teamBusiness.Get(teamId);
            }
            RemoveAllParticipantsFromTeam(teamId);
            RemoveRobotFromTeam(teamId);

            teamBusiness.Delete(teamId);
            Console.WriteLine("Successful operation");
            AfterRegistrationMenu();
            //}
            // catch (Exception)
            // {
            //     Console.WriteLine("Unsuccessful operation");
            // }
        }
        private void ListAllTeams()
        {
            TeamBusiness teamBusiness = new TeamBusiness();
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "TEAMS" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var teams = teamBusiness.GetAll();
            foreach (var team in teams)
            {
                Console.WriteLine("ID: #{0} | Team name: {1} | Number of people in the team: {2}\n", team.TeamId, team.TeamName, team.Number);
            }
        }

        //-----------------------------------------------------------------------
        //RobotUpdates
        private void UpdateRobot()
        {
            RobotBusiness robotBusiness = new RobotBusiness();
            //ListAllRobots();
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Robot robot = robotBusiness.Get(id);
            Console.WriteLine("* Change name: ");
            string change = Console.ReadLine();
            change.ToLower();
            if (robot != null)
            {
                robot.RobotName = Console.ReadLine();
            }

            else
            {
                Console.WriteLine("Product not found!");
            }
            robotBusiness.Update(robot);
        }

        private void DeleteRobot()
        {
            RobotBusiness robotBusiness = new RobotBusiness();
            try
            {
                Console.WriteLine("Enter ID to delete: ");
                int id = int.Parse(Console.ReadLine());
                robotBusiness.Delete(id);
                Console.WriteLine("Successful operation");
                Console.WriteLine("Create a new robot");
                Robot robot = new Robot();
                CreateRobot(robot);
            }
            catch (Exception)
            {
                Console.WriteLine("Unsuccessful operation");
            }
        }
        private void RemoveRobotFromTeam(int id)
        {
            RobotBusiness robotBusiness = new RobotBusiness();
            TeamBusiness teamBusiness = new TeamBusiness();
            Team team = teamBusiness.Get(id);
            var robots = robotBusiness.GetAll();
            foreach (var r in robots)
            {
                if (r.TeamId == id)
                {
                    int roboId = r.RobotId;
                    robotBusiness.Delete(roboId);
                }

            }
        }

        private void ListAllRobots()
        {
            RobotBusiness robotBusiness = new RobotBusiness();
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "ROBOTS" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var robots = robotBusiness.GetAll();
            foreach (var robot in robots)
            {
                Console.WriteLine("ID: #{0} | Robot name: {1}", robot.RobotId, robot.RobotName);
            }
        }
        private void JoinRobotsAndTeams()
        {
            RobotBusiness robotBusiness = new RobotBusiness();
            TeamBusiness teamBusiness = new TeamBusiness();
            var robots = robotBusiness.GetAll();
            foreach (var robot in robots)
            {
                Team team = teamBusiness.Get(robot.TeamId);
                Console.WriteLine("Robot ID: #{0} | Robot name: {1} | Team ID: #{2} | Team name: {3}", robot.RobotId, robot.RobotName, team.TeamId, team.TeamName);
            }
        }

        //--------------------------------------------------------------------
        //Competition
        private void ListAllCompetitions()
        {
            CompetitionBusiness competitionBusiness = new CompetitionBusiness();

            List<Competition> competitions = competitionBusiness.GetAll();

            if (competitions != null)
            {
                foreach (var competition in competitions)
                    Console.WriteLine("ID: #{0} | Competition name: {1} | City: {2} | Country: {3} | Place: {4} | Date and hour: {5}", competition.Id, competition.Name, competition.City, competition.Country, competition.Place, competition.DateTime);

            }
            else
                Console.WriteLine("No available competitions");

        }

        //Judge
        private void JudgesMenu()
        {
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 0:
                    Environment.Exit(0); break;
                case 1:
                    JoinRobotsAndTeams();
                    RobotEvaluate();
                    break;
                case 2:
                    ListAllParticipants(); break;
                case 3:
                    ListAllTeams();
                    int id = int.Parse(Console.ReadLine());
                    ListAllParticipantsInTeam(id); break;
                case 4: 
                    ListAllTeams(); break;
                case 5: 
                    ListAllRobots(); break;
                case 6: 
                    ListAllCompetitions(); break;
                case 7:
                    Ranking(); break;
                case 8:
                    RankingWinners(); break;

                default: break;

            }
        }
        private void RobotEvaluate()
        {
            RobotBusiness robotBusiness = new RobotBusiness();
            TeamBusiness teamBusiness = new TeamBusiness();
            Console.WriteLine("Enter the id of the robot you want to evaluate");
            int id = int.Parse(Console.ReadLine());
            Robot robot = robotBusiness.Get(id);

            Console.WriteLine("Enter speed for the robot");
            int speed = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter strength for the robot");
            int strength = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter intelligence for the robot");
            int intelligence = int.Parse(Console.ReadLine());

            robot.Speed = speed;
            robot.Strength = strength;
            robot.Intelligence = intelligence;
            robotBusiness.Evaluate(robot);

            int points = (int)robotBusiness.SumPoints(speed, strength, intelligence);
            Console.WriteLine("Total points: {0}", points);
            robot.Points = points;
            robotBusiness.UpdateRobotPoints(robot.RobotId, points);

            Team team = teamBusiness.Get(robot.TeamId);
            team.Points = points;
            teamBusiness.Update(team);

        }
        private void Ranking()
        {
            Console.WriteLine("Ranking of all robots:");
            RobotBusiness robotBusiness = new RobotBusiness();
            TeamBusiness teamBusiness = new TeamBusiness();
            var teams = teamBusiness.GetAll();
            var robots = robotBusiness.GetAll();
            robots = robots.OrderByDescending(x => x.Points).ToList();
            foreach (var robot in robots)
            {
                foreach (var team in teams)
                {
                    if (robot.TeamId == team.TeamId)
                    {
                        Console.WriteLine("Robot ID: #{0} | Name: {1} | Speed: {2} | Strength: {3} | Intelligence: {4} | Points: {5} | Team ID: #{6} | Team name: {7}", robot.RobotId, robot.RobotName, robot.Speed, robot.Strength, robot.Intelligence, robot.Points, team.TeamId, team.TeamName);
                    }
                }
            }
            
        }
        private void RankingWinners()
        {
            Console.WriteLine("THE WINNERS ARE:");
            RobotBusiness robotBusiness = new RobotBusiness();
            TeamBusiness teamBusiness = new TeamBusiness();
            var teams = teamBusiness.GetAll();
            var robots = robotBusiness.GetAll();
            robots = robots.OrderByDescending(x => x.Points).Take(3).ToList();
            foreach (var robot in robots)
            {
                foreach (var team in teams)
                {
                    if (robot.TeamId == team.TeamId)
                    {
                        Console.WriteLine("Robot ID: #{0} | Name: {1} | Speed: {2} | Strength: {3} | Intelligence: {4} | Points: {5} | Team ID: #{6} | Team name: {7}", robot.RobotId, robot.RobotName, robot.Speed, robot.Strength, robot.Intelligence, robot.Points, team.TeamId, team.TeamName);
                    }
                }
            }
        }
    }
}
