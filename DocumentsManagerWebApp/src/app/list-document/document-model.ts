import { Footer } from "./footer";
import { Header } from "./header";
import { Parragraph } from "./parragraph";
import { StyleModel } from "../list-styles/styleModel";
import { Format } from "../list-format/format";

export class DocumentModel {
    id:string;
    title: string;
    format: Format;
    style: StyleModel;
    parragraphs: Parragraph[];
    footer: Footer;
    header: Header;
    
    constructor(){
        this.parragraphs=[];
        this.footer=new Footer;
        this.header=new Header;
        this.id="";
        this.title="";
        this.format=new Format;
        this.style=new StyleModel;
    }
  }
 