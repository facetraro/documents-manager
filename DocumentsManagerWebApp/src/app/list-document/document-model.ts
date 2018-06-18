import { Footer } from "./footer";
import { Header } from "./header";
import { Parragraph } from "./parragraph";

export class DocumentModel {
    id:string;
    parragraphs: Parragraph[];
    footer: Footer;
    header: Header;
    
    constructor(){
        this.parragraphs=[];
        this.footer=new Footer;
        this.header=new Header;
        this.id="";
    }
  }
 