import { StyleModel } from "../list-styles/styleModel";

export class Footer {
    id:string;
    text:string;
    style:StyleModel;

    
    constructor(){
        this.id="";
        this.text="";
        this.style=new StyleModel;
    }
  }
 