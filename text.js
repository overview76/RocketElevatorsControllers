class Elevator{
    constructor(id, floorsLVL){
        this.id = id;
        this.floorsLVL = floorsLVL;
        this.elevstats = "idle"
        this.doorsStats = "close" 
    }
}
let Elevator1 = new Elevator(2, 5)
console.log(Elevator1)
