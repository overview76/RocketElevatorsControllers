// Help William Jacques

package main

import (
	"fmt"
	"math"
)

type Battery struct {
	id, nbOfColumnInBattery, nbOfBasement int
	listColumnInBattery                   []Column
}

type Column struct {
	id, maxFloor, minFloor int
	listElevInColumn       []Elevator
}

type Elevator struct {
	id, position       int
	direction          string
	listMoveInElevator []int
}

func main() {

	elevator1 := Elevator{1, -4, "idle", []int{}}
	elevator2 := Elevator{2, 1, "idle", []int{}}
	elevator3 := Elevator{3, -5, "down", []int{}}
	elevator4 := Elevator{4, 1, "up", []int{}}
	elevator5 := Elevator{5, -6, "down", []int{}}

	elevator6 := Elevator{6, 20, "down", []int{}}
	elevator7 := Elevator{7, 3, "up", []int{}}
	elevator8 := Elevator{8, 13, "down", []int{}}
	elevator9 := Elevator{9, 15, "down", []int{}}
	elevator10 := Elevator{10, 6, "down", []int{}}

	elevator11 := Elevator{11, 1, "up", []int{}}
	elevator12 := Elevator{12, 23, "up", []int{}}
	elevator13 := Elevator{13, 33, "down", []int{}}
	elevator14 := Elevator{14, 40, "down", []int{}}
	elevator15 := Elevator{15, 39, "down", []int{}}

	elevator16 := Elevator{16, 58, "down", []int{}}
	elevator17 := Elevator{17, 50, "up", []int{}}
	elevator18 := Elevator{18, 46, "up", []int{}}
	elevator19 := Elevator{19, 1, "up", []int{}}
	elevator20 := Elevator{20, 60, "down", []int{}}

	columnOne := Column{1, 1, -6, []Elevator{}}
	columnTwo := Column{2, 20, 2, []Elevator{}}
	columnthree := Column{3, 40, 21, []Elevator{}}
	columnFour := Column{4, 60, 41, []Elevator{}}

	batteryOne := Battery{1, 4, 6, []Column{}}

	columnOne.listElevInColumn = append(columnOne.listElevInColumn, elevator1)
	columnOne.listElevInColumn = append(columnOne.listElevInColumn, elevator2)
	columnOne.listElevInColumn = append(columnOne.listElevInColumn, elevator3)
	columnOne.listElevInColumn = append(columnOne.listElevInColumn, elevator4)
	columnOne.listElevInColumn = append(columnOne.listElevInColumn, elevator5)

	columnTwo.listElevInColumn = append(columnTwo.listElevInColumn, elevator6)
	columnTwo.listElevInColumn = append(columnTwo.listElevInColumn, elevator7)
	columnTwo.listElevInColumn = append(columnTwo.listElevInColumn, elevator8)
	columnTwo.listElevInColumn = append(columnTwo.listElevInColumn, elevator9)
	columnTwo.listElevInColumn = append(columnTwo.listElevInColumn, elevator10)

	columnthree.listElevInColumn = append(columnthree.listElevInColumn, elevator11)
	columnthree.listElevInColumn = append(columnthree.listElevInColumn, elevator12)
	columnthree.listElevInColumn = append(columnthree.listElevInColumn, elevator13)
	columnthree.listElevInColumn = append(columnthree.listElevInColumn, elevator14)
	columnthree.listElevInColumn = append(columnthree.listElevInColumn, elevator15)

	columnFour.listElevInColumn = append(columnFour.listElevInColumn, elevator16)
	columnFour.listElevInColumn = append(columnFour.listElevInColumn, elevator17)
	columnFour.listElevInColumn = append(columnFour.listElevInColumn, elevator18)
	columnFour.listElevInColumn = append(columnFour.listElevInColumn, elevator19)
	columnFour.listElevInColumn = append(columnFour.listElevInColumn, elevator20)

	batteryOne.listColumnInBattery = append(batteryOne.listColumnInBattery, columnOne)
	batteryOne.listColumnInBattery = append(batteryOne.listColumnInBattery, columnTwo)
	batteryOne.listColumnInBattery = append(batteryOne.listColumnInBattery, columnthree)
	batteryOne.listColumnInBattery = append(batteryOne.listColumnInBattery, columnFour)

	batteryOne.requestElevator(20, "up", 1)
	fmt.Println("")
	batteryOne.requestElevator(36, "up", 1)
	fmt.Println("")
	batteryOne.requestElevator(1, "down", 54)
	fmt.Println("")
	batteryOne.requestElevator(1, "up", -3)
}

// Request Elevator From user
func (battery Battery) requestElevator(requestedFloor int, direction string, userCurrentFloor int) Elevator {

	if userCurrentFloor != 1 {
		columnFinded := battery.columnToFindUserCurrentFloor(userCurrentFloor)
		elevatorFinded := columnFinded.ElevatorInTheChosenColumn(columnFinded, requestedFloor, direction, userCurrentFloor)
		fmt.Println("Elevator choosen is : ", elevatorFinded.id)
		return elevatorFinded
	} else {
		columnFinded := battery.columnToFindRequestedFloor(requestedFloor)
		elevatorFinded := columnFinded.ElevatorInTheChosenColumn(columnFinded, requestedFloor, direction, userCurrentFloor)
		fmt.Println("Elevator choosen is : ", elevatorFinded.id)
		return elevatorFinded
	}
}

// -------- ELevator move -------------
func (elevator Elevator) moveToRequestedFloor(userCurrentFloor int) {

	if elevator.position > userCurrentFloor {

		for elevator.position > userCurrentFloor {
			elevator.position = elevator.position - 1

		}
	}

	if elevator.position < userCurrentFloor {
		for elevator.position < userCurrentFloor {

			elevator.position = elevator.position + 1

		}
	}
	fmt.Println("Elevator", elevator.id, "is at the position", elevator.position)
}

func (battery Battery) columnToFindUserCurrentFloor(userCurrentFloor int) Column {

	for _, column := range battery.listColumnInBattery {
		if userCurrentFloor <= column.maxFloor && userCurrentFloor >= column.minFloor {
			fmt.Println("The choosen column is ", column.id)
			return column
		}

	}

	return battery.listColumnInBattery[0]
}

func (battery Battery) columnToFindRequestedFloor(requestedFloor int) Column {

	for _, column := range battery.listColumnInBattery {
		if requestedFloor <= column.maxFloor && requestedFloor >= column.minFloor {
			fmt.Println("The choosen column is ", column.id)
			return column
		}

	}

	return battery.listColumnInBattery[0]
}

func (elevator Elevator) moveToUserCurrentFloor(userCurrentFloor int) {

	if elevator.position > userCurrentFloor {
		for elevator.position > userCurrentFloor {

			elevator.position = elevator.position - 1

		}
	}
	if elevator.position < 1 {
		for elevator.position > userCurrentFloor {
			elevator.position = elevator.position + 1

		}
	}
	fmt.Println("Elevator", elevator.id, "is at the position", elevator.position)
}

// -------- Find best elevator in the chosen column -------------

func (column Column) ElevatorInTheChosenColumn(columnFinded Column, requestedFloor int, direction string, userCurrentFloor int) Elevator {

	var bestNearestElevatorGap = 10000000
	var bestElevator Elevator
	var bestCase = 0

	for _, elevator := range columnFinded.listElevInColumn {
		// Condition 1
		if userCurrentFloor == elevator.position {
			// BestCase 1
			if bestCase == 0 || bestCase > 1 {
				bestCase = 1
				bestElevator = elevator

				// if user is at floor 1
			}
			if bestCase == 1 && requestedFloor > 1 {
				var gap = int(math.Abs(float64(elevator.position - 1)))
				if bestNearestElevatorGap >= gap {
					bestElevator = elevator
					bestNearestElevatorGap = gap
				}
			} // if user is not at floor 1
			if bestCase == 1 && requestedFloor != 1 {
				var gap = int(math.Abs(float64(elevator.position - requestedFloor)))
				if bestNearestElevatorGap >= gap {
					bestElevator = elevator
					bestNearestElevatorGap = gap
				}
			}
		}

		// condition 2
		if elevator.position > userCurrentFloor && requestedFloor == 1 {

			// BestCase 2
			if bestCase == 0 || bestCase > 2 {
				bestCase = 2
				bestElevator = elevator

			} // if user is at floor 1
			if bestCase == 2 && requestedFloor > 2 {
				var gap = int(math.Abs(float64(elevator.position - 1)))
				if bestNearestElevatorGap >= gap {
					bestElevator = elevator
					bestNearestElevatorGap = gap

				}
				// if user is not at floor 1
			} else if bestCase == 2 && requestedFloor != 1 {
				var gap = int(math.Abs(float64(elevator.position - requestedFloor)))
				if bestNearestElevatorGap >= gap {
					bestElevator = elevator
					bestNearestElevatorGap = gap
				}
			}
		}
		// Condition 3
		if elevator.position > 1 && direction == "up" && elevator.direction == "down" {
			// BestCase 3
			if bestCase == 0 || bestCase > 3 {
				bestCase = 3
				bestElevator = elevator

			} // if user is at floor 1
			if bestCase == 3 && requestedFloor > 1 {
				var gap = int(math.Abs(float64(elevator.position - 1)))
				if bestNearestElevatorGap >= gap {
					bestElevator = elevator
					bestNearestElevatorGap = gap

				}
				// if user is not at floor 1
			} else if bestCase == 3 && requestedFloor != 1 {
				var gap = int(math.Abs(float64(elevator.position - requestedFloor)))
				if bestNearestElevatorGap >= gap {
					bestElevator = elevator
					bestNearestElevatorGap = gap
				}
			}
		}
		// Condition 4
		if elevator.direction == "idle" {
			// BestCase 4
			if bestCase == 0 || bestCase > 4 {
				bestCase = 4
				bestElevator = elevator

			}
			// if user is at floor 1
			if bestCase == 4 && requestedFloor > 1 {
				var gap = int(math.Abs(float64(elevator.position - 1)))
				if bestNearestElevatorGap >= gap {
					bestElevator = elevator
					bestNearestElevatorGap = gap
				}
			} // if user is not at floor 1
			if bestCase == 4 && requestedFloor != 1 {
				var gap = int(math.Abs(float64(elevator.position - requestedFloor)))
				if bestNearestElevatorGap >= gap {
					bestElevator = elevator
					bestNearestElevatorGap = gap
				}
			}
		}
	}
	bestElevator.moveToUserCurrentFloor(userCurrentFloor)
	bestElevator.moveToRequestedFloor(requestedFloor)

	return bestElevator
}
