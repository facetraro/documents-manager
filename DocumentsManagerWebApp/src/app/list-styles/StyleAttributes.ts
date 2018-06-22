export class StyleAttributes {
    type:string;
    value:string;
    
    constructor(){
        this.type="";
        this.value="";
    }

    toString():string{
        if(this.value.length==0){
            return this.type;
        } else {
            return this.type+"###"+this.value;
        }
    }
  }
 