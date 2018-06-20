import { StyleModel } from "../list-styles/styleModel";
import { Header } from "./header";

export class Parragraph {
    id:string;
    texts:Header[];
    style:StyleModel;
    
    constructor(){
        this.id="";
        this.texts=[];
        this.style=new StyleModel;
    }
  }
 