//help loic rico chirst saravia jean-francois Taillefer Anthony pageau
class Elevators {
    constructor(numElevators, floorNumber) {
        this.numElevators = numElevators;
        this.currentFloor = 1;
        this.direction = null;
        this.status = "Idle";
        this.floorList = [];
    }

    movingDown() {
        if (this.status == "Idle" ) {
            this.status = "moving";
            this.direction = "Down";
        }
        this.currentFloor--;
    }

    movingUp() {
        if (this.status == "Idle") {
            this.status = "moving";
            this.direction = "Up";
        }
        this.currentFloor++;
    }
}

class Columns {
    constructor(numElevators, floorNumber) {
        this.numElevators = numElevators;
        this.floorNumber = floorNumber;
        this.elevators = [];
        for (let i = 0; i < this.numElevators; i++) {
            this.elevators.push(new Elevators(floorNumber));
        }
    }
}

class Button {
    constructor(requestFloor) {
        this.requestFloor = requestFloor;
    }
}

class ExternalFloorBtn {
    constructor(direction, requestFloor, status) {
        this.requestFloor = requestFloor;
        this.direction = direction;
        this.status = status;
    }
}

class RequestedFloor {
    constructor(numElevators, status, requestFloor) {
        this.numElevators = numElevators;
        this.status = status;
        this.requestFloor = requestFloor;
    }
}

class ElevatorController {
    constructor(floorNumber, numElevators) {
        this.floorNumber = floorNumber;
        this.numElevators = numElevators;
        this.btnList = [];
        this.elevatorList = [];
        for (let i = 1; i < floorNumber; i++) {
            this.btnList.push(new Button('Up', i, 'off'));
            this.btnList.push(new Button('Down', i + 1, 'off'));
        }
        for (let i = 1; i <= numElevators; i++) {
            this.elevatorList.push(new Elevators(i, floorNumber));
        }
    }

    
    bestElevator(floorList, direction){ 
        if (direction === "Up"){
            var z;
            do {
                z = false;
                for (var i=0; i < floorList.length-1; i++) {
                    if (floorList[i] > floorList[i+1]) {
                        var temp = floorList[i];
                        floorList[i] = floorList[i+1];
                        floorList[i+1] = temp;
                        z = true;
                    }
                }
            } while (z);
        }
        
        else if(direction === "Down"){
            do {
                z = false;
                for (var i=0; i < floorList.length-1; i++) {
                    if (floorList[i] < floorList[i+1]) {
                        var temp = floorList[i];
                        floorList[i] = floorList[i+1];
                        floorList[i+1] = temp;
                        z = true;
                    }
                }
            } while (z);
        }
        console.log("Sorted floorList : ", floorList);
    }

    findBestElevator(floorNumber, direction, elevList) {
        console.log("findBEstElevator");
        while (true) {
            for (var i = 0; i < elevList.length; i++) {
                var x = elevList[i];
                console.log("elevator " + x.numElevators);
                console.log("floorNumber " + floorNumber);
                console.log("current floor " + x.currentFloor);
                if (x.status === "STOPPED" && x.currentFloor === floorNumber && x.direction === direction) {
                    console.log("findBEstElevator 1");
                    x.floorList.push(floorNumber);
                    return x;
                } else if (x.status === "Idle" && x.currentFloor === floorNumber) {
                    console.log("findBEstElevator 2");
                    x.floorList.push(floorNumber);
                    return x;
                } else if (x.currentFloor < floorNumber && (x.status === "moving" || "STOPPED") && x.direction === "Up" && direction === x.direction) {
                    console.log("findBEstElevator 3");
                    x.floorList.push(floorNumber);
                    return x;
                } else if (x.currentFloor > floorNumber && (x.status === "moving" || "STOPPED") && x.direction === "Down" && direction === x.direction) {
                    console.log("findBEstElevator 4");
                    x.floorList.push(floorNumber);
                    return x;
                } else if (x.status === "Idle") {
                    console.log("findBEstElevator 5");
                    x.floorList.push(floorNumber);
                    return x;
                }
                else {
                    console.log("findBEstElevator6");
                    var x = this.shortestList(elevList);
                    return x;
                }
            }
        }
    }

    requestElevator(FloorNumber, Direction) {
        var elevator = this.findBestElevator(FloorNumber, Direction, this.elevatorList)
        console.log("Find best elevator has retrned : " + elevator.numElevators)
        this.operateElevator(elevator, Direction)
    }

    requestFloor(Elevator, RequestedFloor) {
        var elevator = this.requestElevator(RequestedFloor, direction, this.elevatorList)
        this.operateElevator(Elevator, Direction)
    }

    operateElevator(Elevator, Direction) {
        console.log("next item on floor list : ", Elevator.floorList[0])
        while (Elevator.floorList.length > 0) {
            console.log("current floor : ", Elevator.currentFloor)
            if (Elevator.floorList[0] === Elevator.currentFloor) {
                Elevator.floorList.shift()
                console.log("new list : ", Elevator.floorList);
                console.log("next destination : ", Elevator.floorList[0])
            }
            if (Elevator.floorList[0] > Elevator.currentFloor) {
                Elevator.movingUp(Elevator);
            }
            if (Elevator.floorList[0] < Elevator.currentFloor) {
                Elevator.movingDown();
            }
        }
        if (Elevator.floorList.length < 1) {
            Elevator.status = "Idle";
            Elevator.direction = null;
        }
    }

    shortestList(elevlist) {
        var length = 9999
        for (var i = 0; i < elevlist.length; i++) {
            if (length > elevlist[i].floorList.length) {
                length = elevlist[i].floorList.length
                var y = elevlist[i]
            }
        }
        return y;
    }
}

//Elevator 1
let elevatorController = new ElevatorController(3, 2);
elevatorController.elevatorList[0].currentFloor = 3;
elevatorController.elevatorList[0].direction = null;
elevatorController.elevatorList[0].status = "Idle";
elevatorController.elevatorList[0].floorList = [];
console.log( elevatorController.elevatorList[0].numElevators)

//Elevator 2
elevatorController.elevatorList[1].currentFloor = 10;
elevatorController.elevatorList[1].direction = null;
elevatorController.elevatorList[1].status = "Idle";
elevatorController.elevatorList[1].floorList = [];
console.log( elevatorController.elevatorList[1].numElevators)


elevatorController.requestElevator(10, "Down");
