
class Elevators:
    def __init__(self, numElevators, floorNumber):
        self.numElevators = numElevators
        self.currentFloor = 1
        self.direction = None
        self.status = "Idle"
        self.floorList = []
    

    def movingDown():
        if self.status == "Idle":  
            self.status = "moving"
            self.direction = "Down"
        
        self.currentFloor--
    

    movingUp() {
        if (self.status == "Idle") {
            self.status = "moving"
            self.direction = "Up"
        }
        self.currentFloor++
    }
}

class Columns {
    constructor(numElevators, floorNumber) {
        self.numElevators = numElevators
        self.floorNumber = floorNumber
        self.elevators = []
        for (let i = 0 i < self.numElevators i++) {
            self.elevators.push(new Elevators(floorNumber))
        }
    }
}

class Button {
    constructor(requestFloor) {
        self.requestFloor = requestFloor
    }
}

class ExternalFloorBtn {
    constructor(direction, requestFloor, status) {
        self.requestFloor = requestFloor
        self.direction = direction
        self.status = status
    }
}

class RequestedFloor {
    constructor(numElevators, status, requestFloor) {
        self.numElevators = numElevators
        self.status = status
        self.requestFloor = requestFloor
    }
}

class ElevatorController {
    constructor(floorNumber, numElevators) {
        self.floorNumber = floorNumber
        self.numElevators = numElevators
        self.btnList = []
        self.elevatorList = []
        for (let i = 1 i < floorNumber i++) {
            self.btnList.push(new Button('Up', i, 'off'))
            self.btnList.push(new Button('Down', i + 1, 'off'))
        }
        for (let i = 1 i <= numElevators i++) {
            self.elevatorList.push(new Elevators(i, floorNumber))
        }
    }

    
    bestElevator(floorList, direction){ 
        if (direction === "Up"){
            var z
            do {
                z = false
                for (var i=0 i < floorList.length-1 i++) {
                    if (floorList[i] > floorList[i+1]) {
                        var temp = floorList[i]
                        floorList[i] = floorList[i+1]
                        floorList[i+1] = temp
                        z = true
                    }
                }
            } while (z)
        }
        
        else if(direction === "Down"){
            do {
                z = false
                for (var i=0 i < floorList.length-1 i++) {
                    if (floorList[i] < floorList[i+1]) {
                        var temp = floorList[i]
                        floorList[i] = floorList[i+1]
                        floorList[i+1] = temp
                        z = true
                    }
                }
            } while (z)
        }
        print("Sorted floorList : ", floorList)
    }

    findBestElevator(floorNumber, direction, elevList) {
        print("findBEstElevator")
        while (true) {
            for (var i = 0 i < elevList.length i++) {
                var x = elevList[i]
                print("elevator " + x.numElevators)
                print("floorNumber " + floorNumber)
                print("current floor " + x.currentFloor)
                if (x.status === "STOPPED" && x.currentFloor === floorNumber && x.direction === direction) {
                    print("findBEstElevator 1")
                    x.floorList.push(floorNumber)
                    return x
                } else if (x.status === "Idle" && x.currentFloor === floorNumber) {
                    print("findBEstElevator 2")
                    x.floorList.push(floorNumber)
                    return x
                } else if (x.currentFloor < floorNumber && (x.status === "moving" || "STOPPED") && x.direction === "Up" && direction === x.direction) {
                    print("findBEstElevator 3")
                    x.floorList.push(floorNumber)
                    return x
                } else if (x.currentFloor > floorNumber && (x.status === "moving" || "STOPPED") && x.direction === "Down" && direction === x.direction) {
                    print("findBEstElevator 4")
                    x.floorList.push(floorNumber)
                    return x
                } else if (x.status === "Idle") {
                    print("findBEstElevator 5")
                    x.floorList.push(floorNumber)
                    return x
                }
                else {
                    print("findBEstElevator6")
                    var x = self.shortestList(elevList)
                    return x
                }
            }
        }
    }

    requestElevator(FloorNumber, Direction) {
        var elevator = self.findBestElevator(FloorNumber, Direction, self.elevatorList)
        print("Find best elevator has retrned : " + elevator.numElevators)
        self.operateElevator(elevator, Direction)
    }

    requestFloor(Elevator, RequestedFloor) {
        var elevator = self.requestElevator(RequestedFloor, direction, self.elevatorList)
        self.operateElevator(Elevator, Direction)
    }

    operateElevator(Elevator, Direction) {
        print("next item on floor list : ", Elevator.floorList[0])
        while (Elevator.floorList.length > 0) {
            print("current floor : ", Elevator.currentFloor)
            if (Elevator.floorList[0] === Elevator.currentFloor) {
                Elevator.floorList.shift()
                print("new list : ", Elevator.floorList)
                print("next destination : ", Elevator.floorList[0])
            }
            if (Elevator.floorList[0] > Elevator.currentFloor) {
                Elevator.movingUp(Elevator)
            }
            if (Elevator.floorList[0] < Elevator.currentFloor) {
                Elevator.movingDown()
            }
        }
        if (Elevator.floorList.length < 1) {
            Elevator.status = "Idle"
            Elevator.direction = null
        }
    }

    shortestList(elevlist) {
        var length = 9999
        for (var i = 0 i < elevlist.length i++) {
            if (length > elevlist[i].floorList.length) {
                length = elevlist[i].floorList.length
                var y = elevlist[i]
            }
        }
        return y
    }
}


print("main2")
//Elevator 1
let elevatorController = new ElevatorController(3, 2)
elevatorController.elevatorList[0].currentFloor = 3
elevatorController.elevatorList[0].direction = null
elevatorController.elevatorList[0].status = "Idle"
elevatorController.elevatorList[0].floorList = []
print("*****" + elevatorController.elevatorList[0].numElevators)

//Elevator 2
elevatorController.elevatorList[1].currentFloor = 10
elevatorController.elevatorList[1].direction = null
elevatorController.elevatorList[1].status = "Idle"
elevatorController.elevatorList[1].floorList = []
print("*****" + elevatorController.elevatorList[1].numElevators)


elevatorController.requestElevator(10, "Down")