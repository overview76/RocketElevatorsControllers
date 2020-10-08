//--------------Help Jean-Francois Taillefer Christ Saravia LOÏC RICO Anthony Pageau
//-------------- Like on the video for C#  https://www.youtube.com/watch?v=GhQdlIFylQ8&t=13122s
//-------------- Object whit C# https://www.w3schools.com/cs/default.asp
//-------------- Make whit visual studio move on visual studio code  for the repo
// The last week was hard but we stay positive
// I love doing that I just have to put my 100% on it 


using System;
using System.Collections.Generic;

namespace myapp
{
    // ------------------- Class Battery ---------------------------
    class Battery
    {
        public int id;
        public int nbOfColumnInBattery;
        public int nbOfBasement;
        public List<Column> listColumnInBattery;
        public Battery(int id, int nbOfColumnInBattery, int nbOfBasement, List<Column> listColumnInBattery)
        {
            this.id = id;
            this.nbOfColumnInBattery = nbOfColumnInBattery;
            this.nbOfBasement = nbOfBasement;
            this.listColumnInBattery = listColumnInBattery;
        }
        //  Request Elevator by user
        public Elevator requestElevator(int requestedFloor, String direction, int userCurrentFloor)
        {
            // if user is not at floor 1 call columnToFindUser_CurrentFloor
            if (userCurrentFloor != 1)
            {
                Column columnFinded = this.columnToFindUser_CurrentFloor(userCurrentFloor);
                // calling function ElevatorInTheChosenColumn
                Elevator elevatorFinded = columnFinded.ElevatorInTheChosenColumn(columnFinded, requestedFloor, direction, userCurrentFloor);
                Console.WriteLine("Elevator choosen is : " + elevatorFinded.id);
                return elevatorFinded;
            }// else call columnToFind_RequestedFloor
            else
            {
                Column columnFinded = this.columnToFind_RequestedFloor(requestedFloor);
                // calling function ElevatorInTheChosenColumn
                Elevator elevatorFinded = columnFinded.ElevatorInTheChosenColumn(columnFinded, requestedFloor, direction, userCurrentFloor);
                Console.WriteLine("Elevator choosen is : " + elevatorFinded.id);
                return elevatorFinded;
            }
        }

        //  If the userCurrentFloor is between max floor and min floor return the right column and repeat for each column in listColumnInBattery
        public Column columnToFindUser_CurrentFloor(int userCurrentFloor)
        {
            foreach (Column column in listColumnInBattery)
            {
                if (userCurrentFloor <= column.maxFloor && userCurrentFloor >= column.minFloor)
                {
                    Console.WriteLine("The choosen column is " + column.id);
                    return column;
                }
            }
            return listColumnInBattery[0];
        }
        //  If the requestedFloor is between max floor and min floor return the right column and repeat for each column in listColumnInBattery
        public Column columnToFind_RequestedFloor(int requestedFloor)
        {
            foreach (Column column in listColumnInBattery)
            {
                if (requestedFloor <= column.maxFloor && requestedFloor >= column.minFloor)
                {
                    Console.WriteLine("The choosen column is " + column.id);
                    return column;
                }
            }
            return listColumnInBattery[0];
        }
    }

    // ------------------- Class Column ---------------------------
    class Column
    {
        public int id;
        public List<Elevator> listElevInColumn;
        public int maxFloor;
        public int minFloor;

        public Column(int id, List<Elevator> listElevInColumn, int maxFloor, int minFloor)
        {
            this.id = id;
            this.listElevInColumn = listElevInColumn;
            this.maxFloor = maxFloor;
            this.minFloor = minFloor;
        }

        // Find best elevator in the chosen column
        public Elevator ElevatorInTheChosenColumn(Column columnFinded, int requestedFloor, String direction, int userCurrentFloor)
        {

            var bestNearestElevatorGap = 10000000;
            Elevator bestElevator = null;
            var bestCase = 0;

            foreach (Elevator elevator in columnFinded.listElevInColumn)
            {
                // Condition 1
                if (userCurrentFloor == elevator.position)
                {
                    // BestCase 1

                    if (bestCase == 0 || bestCase > 1)
                    {
                        bestCase = 1;
                        bestElevator = elevator;

                        // if user is at floor 1
                    }
                    else if (bestCase == 1 && requestedFloor > 1)
                    {
                        var gap = Math.Abs(elevator.position - 1);
                        if (bestNearestElevatorGap >= gap)
                        {
                            bestElevator = elevator;
                            bestNearestElevatorGap = gap;
                        }
                    }  // if user is not at floor 1
                    else if (bestCase == 1 && requestedFloor != 1)
                    {
                        var gap = Math.Abs(elevator.position - requestedFloor);
                        if (bestNearestElevatorGap >= gap)
                        {
                            bestElevator = elevator;
                            bestNearestElevatorGap = gap;
                        }
                    }
                }


                // condition 2
                else if (elevator.position > userCurrentFloor && requestedFloor == 1)
                {

                    // BestCase 2
                    if (bestCase == 0 || bestCase > 2)
                    {
                        bestCase = 2;
                        bestElevator = elevator;

                    }// if user is at floor 1
                    else if (bestCase == 2 && requestedFloor > 2)
                    {
                        var gap = Math.Abs(elevator.position - 1);
                        if (bestNearestElevatorGap >= gap)
                        {
                            bestElevator = elevator;
                            bestNearestElevatorGap = gap;

                        }
                        // if user is not at floor 1
                    }
                    else if (bestCase == 2 && requestedFloor != 1)
                    {
                        var gap = Math.Abs(elevator.position - requestedFloor);
                        if (bestNearestElevatorGap >= gap)
                        {
                            bestElevator = elevator;
                            bestNearestElevatorGap = gap;
                        }
                    }
                }


                else if (elevator.position > 1 && direction == "down" && elevator.direction == "down")
                {
                    // BestCase 3
                    if (bestCase == 0 || bestCase > 3)
                    {
                        bestCase = 3;
                        bestElevator = elevator;

                    }// if user is at floor 1
                    else if (bestCase == 3 && requestedFloor > 1)
                    {
                        var gap = Math.Abs(elevator.position - 1);
                        if (bestNearestElevatorGap >= gap)
                        {
                            bestElevator = elevator;
                            bestNearestElevatorGap = gap;

                        }
                        // if user is not at floor 1
                    }
                    else if (bestCase == 3 && requestedFloor != 1)
                    {
                        var gap = Math.Abs(elevator.position - requestedFloor);
                        if (bestNearestElevatorGap >= gap)
                        {
                            bestElevator = elevator;
                            bestNearestElevatorGap = gap;
                        }
                    }
                }

                // Condition 3
                else if (elevator.position > 1 && direction == "up" && elevator.direction == "down")
                {
                    // BestCase 3
                    if (bestCase == 0 || bestCase > 4)
                    {
                        bestCase = 4;
                        bestElevator = elevator;

                    }// if user is at floor 1
                    else if (bestCase == 4 && requestedFloor > 1)
                    {
                        var gap = Math.Abs(elevator.position - 1);
                        if (bestNearestElevatorGap >= gap)
                        {
                            bestElevator = elevator;
                            bestNearestElevatorGap = gap;

                        }
                        // if user is not at floor 1
                    }
                    else if (bestCase == 4 && requestedFloor != 1)
                    {
                        var gap = Math.Abs(elevator.position - requestedFloor);
                        if (bestNearestElevatorGap >= gap)
                        {
                            bestElevator = elevator;
                            bestNearestElevatorGap = gap;
                        }
                    }
                }
                // Condition 4
                else if (elevator.direction == "idle")
                {
                    // BestCase 4
                    if (bestCase == 0 || bestCase > 4)
                    {
                        bestCase = 4;
                        bestElevator = elevator;

                    }
                    // if user is at floor 1
                    else if (bestCase == 4 && requestedFloor > 1)
                    {
                        var gap = Math.Abs(elevator.position - 1);
                        if (bestNearestElevatorGap >= gap)
                        {
                            bestElevator = elevator;
                            bestNearestElevatorGap = gap;
                        }
                    } // if user is not at floor 1
                    else if (bestCase == 4 && requestedFloor != 1)
                    {
                        var gap = Math.Abs(elevator.position - requestedFloor);
                        if (bestNearestElevatorGap >= gap)
                        {
                            bestElevator = elevator;
                            bestNearestElevatorGap = gap;
                        }
                    }
                }
            }
            bestElevator.moveToUserCurrentFloor(userCurrentFloor);
            bestElevator.moveToRequestedFloor(requestedFloor);

            return bestElevator;
        }
    }
    // ------------------- Class Elevator ---------------------------
    class Elevator
    {
        public int id;
        public string direction;
        public int position;
        public List<int> listMoveInElevator;
        public Elevator(int id, string direction, int position, List<int> listMoveInElevator)
        {
            this.id = id;
            this.direction = direction;
            this.position = position;
            this.listMoveInElevator = listMoveInElevator;
        }
        public void moveToRequestedFloor(int requestedFloor)
        {
            if (this.position > requestedFloor)
            {

                while (this.position > requestedFloor)
                    this.position -= 1;
                Console.WriteLine("Elevator " + this.id + " move down to requested floor " + this.position );
            }
            if (this.position < requestedFloor)
            {
                while (this.position < requestedFloor)
                    this.position += 1;
                Console.WriteLine("Elevator " + this.id + " move up to requested floor (" + this.position + ")");
            }
        }

        public void moveToUserCurrentFloor(int userCurrentFloor)
        {
            if (this.position > userCurrentFloor)
            {
                while (this.position > userCurrentFloor)
                    this.position -= 1;
                Console.WriteLine("Elevator " + this.id + " move down to user current floor (" + this.position + ")");
            }
            if (this.position < 1)
            {
                while (this.position < userCurrentFloor)
                    this.position += 1;
                Console.WriteLine("Elevator " + this.id + " move up to user current floor (" + this.position + ")");
            }
        }
    }
    // ------------------- Class Program ---------------------------
    class Program
    {
        static void Main(string[] args)
        {

            // elevators in columnOne (BASEMENT)
            Elevator elevatorA1 = new Elevator(1, "idle", -4, new List<int>());
            Elevator elevatorA2 = new Elevator(2, "idle", 1, new List<int>());
            Elevator elevatorA3 = new Elevator(3, "down", -5, new List<int>());
            Elevator elevatorA4 = new Elevator(4, "up", 1, new List<int>());
            Elevator elevatorA5 = new Elevator(5, "down", -6, new List<int>());


            // elevators in columnTwo
            Elevator elevatorB6 = new Elevator(6, "down", 20, new List<int>());
            Elevator elevatorB7 = new Elevator(7, "up", 3, new List<int>());
            Elevator elevatorB8 = new Elevator(8, "down", 13, new List<int>());
            Elevator elevatorB9 = new Elevator(9, "down", 15, new List<int>());
            Elevator elevatorB10 = new Elevator(10, "down", 6, new List<int>());

            // elevators in columnThree
            Elevator elevatorC11 = new Elevator(11, "up", 1, new List<int>());
            Elevator elevatorC12 = new Elevator(12, "up", 23, new List<int>());
            Elevator elevatorC13 = new Elevator(13, "down", 33, new List<int>());
            Elevator elevatorC14 = new Elevator(14, "down", 40, new List<int>());
            Elevator elevatorC15 = new Elevator(15, "down", 39, new List<int>());

            // elevators in columnFour
            Elevator elevatorD16 = new Elevator(16, "down", 58, new List<int>());
            Elevator elevatorD17 = new Elevator(17, "up", 50, new List<int>());
            Elevator elevatorD18 = new Elevator(18, "up", 46, new List<int>());
            Elevator elevatorD19 = new Elevator(19, "up", 1, new List<int>());
            Elevator elevatorD20 = new Elevator(20, "down", 60, new List<int>());


            // -------column-------
            //  (int id, List<Elevator> listElevInColumn, int maxFloor, int minFloor) 
            Column columnOne = new Column(1, new List<Elevator>(), 1, -6);
            Column columnTwo = new Column(2, new List<Elevator>(), 2, 20);
            Column columnThree = new Column(3, new List<Elevator>(), 40, 21);
            Column columnFour = new Column(4, new List<Elevator>(), 60, 41);

            // add the elevator in the list
            columnOne.listElevInColumn.Add(elevatorA1);
            columnOne.listElevInColumn.Add(elevatorA2);
            columnOne.listElevInColumn.Add(elevatorA3);
            columnOne.listElevInColumn.Add(elevatorA4);
            columnOne.listElevInColumn.Add(elevatorA5);

            columnTwo.listElevInColumn.Add(elevatorB6);
            columnTwo.listElevInColumn.Add(elevatorB7);
            columnTwo.listElevInColumn.Add(elevatorB8);
            columnTwo.listElevInColumn.Add(elevatorB9);
            columnTwo.listElevInColumn.Add(elevatorB10);

            columnThree.listElevInColumn.Add(elevatorC11);
            columnThree.listElevInColumn.Add(elevatorC12);
            columnThree.listElevInColumn.Add(elevatorC13);
            columnThree.listElevInColumn.Add(elevatorC14);
            columnThree.listElevInColumn.Add(elevatorC15);

            columnFour.listElevInColumn.Add(elevatorD16);
            columnFour.listElevInColumn.Add(elevatorD17);
            columnFour.listElevInColumn.Add(elevatorD18);
            columnFour.listElevInColumn.Add(elevatorD19);
            columnFour.listElevInColumn.Add(elevatorD20);

            // -------battery-------
            // (int id, int nbOfColumnInBattery, int nbOfBasement, List<Column> listColumnInBattery)
            Battery batteryOne = new Battery(1, 4, 6, new List<Column>());

            // add the columns in the list.
            batteryOne.listColumnInBattery.Add(columnOne);
            batteryOne.listColumnInBattery.Add(columnTwo);
            batteryOne.listColumnInBattery.Add(columnThree);
            batteryOne.listColumnInBattery.Add(columnFour);

            // ------------------------------- SCENARIO 1 -------------------------------------------------

            batteryOne.requestElevator(20, "down", 1);
            Console.WriteLine("---------------------------");
            // ------------------------------- SCENARIO 2 -------------------------------------------------
            batteryOne.requestElevator(36, "up", 1);
            Console.WriteLine("---------------------------");
            // ------------------------------- SCENARIO 3 -------------------------------------------------
            batteryOne.requestElevator(1, "down", 54);
            Console.WriteLine("----------------------------");
            // ------------------------------- SCENARIO 4 -------------------------------------------------
            batteryOne.requestElevator(1, "up", -3);
            Console.WriteLine("----------------------------");
        }
    }
}