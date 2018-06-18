import { StyleFromFormat } from "./style-from-format";

export class Format {
    id:string;
    name: string;
    styleClasses:StyleFromFormat[];
     
    constructor(){
      this.id = "";
      this.name = "";
      this.styleClasses = [];
    }
  }
 