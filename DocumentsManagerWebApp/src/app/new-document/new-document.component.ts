import { Component, OnInit } from '@angular/core';
import { DocumentModel } from '../list-document/document-model';
import { Footer } from '../list-document/footer';
import { Header } from '../list-document/header';
import { Parragraph } from '../list-document/Parragraph';
import { Format } from '../list-format/format';
import { StyleService } from '../list-styles/style.service';
import { FormatService } from '../list-format/format.service';
import { ManageToken } from '../manage-token';
import { StyleModel } from '../list-styles/styleModel';
import { DocumentService } from '../list-document/document.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-document',
  templateUrl: './new-document.component.html',
  styleUrls: ['./new-document.component.css']
})
export class NewDocumentComponent implements OnInit {
  document:DocumentModel;
  footer:string;
  footerStyle:StyleModel;
  header:string;
  headerStyle:StyleModel;
  simpleText:string;
  simpleStyle:StyleModel;
  parragraphStyle:StyleModel;
  format:Format;
  style:StyleModel;
  parragraphs:Parragraph[];
  actualParragraphs:Header[];
  allStyles:StyleModel[];
  allFormats:Format[];
  tokenManagment:ManageToken;
  styleService: StyleService;
  formatService: FormatService;
  countParragraph:number;
  countTexts:number;
  documentService: DocumentService;
  router:Router;

  constructor(
    styleService: StyleService, 
    formatService: FormatService,
    documentService: DocumentService,
    router: Router
  ) {
    this.router=router;
    this.documentService=documentService;
    this.tokenManagment=new ManageToken;
    this.countParragraph=0;
    this.countTexts=0;
    this.document=new DocumentModel;
    this.footer="";
    this.footerStyle=new StyleModel;
    this.header="";
    this.headerStyle=new StyleModel;
    this.simpleText="";
    this.simpleStyle=new StyleModel;
    this.parragraphStyle=new StyleModel;
    this.format=new Format;
    this.style=new StyleModel;
    this.actualParragraphs=[];
    this.parragraphs=[];
    this.allStyles=[];
    this.allFormats=[];
    this.formatService=formatService;
    this.styleService=styleService;
    this.loadStyles(this.tokenManagment.getToken());
    this.loadFormats(this.tokenManagment.getToken());
  }

  showErrorMessage(error:any){
    alert(error);
  }
  loadFormats(token: string ){
    this.formatService.getAllFormats(token).subscribe(response => this.allFormats=response), 
      error => this.showErrorMessage(error);
  }
  loadStyles(token: string ){
    this.styleService.getAllStyles(token).subscribe(response => this.allStyles=response), 
      error => this.showErrorMessage(error);
  }

  addTextToParragraph(){
     let newSingleParragraph=new Header;
     newSingleParragraph.style=new StyleModel;
     let splitter = this.simpleStyle.id.split("###");
     if(splitter.length==2){
      newSingleParragraph.style.id=splitter[0];
      newSingleParragraph.style.name=splitter[1];
      newSingleParragraph.text=this.simpleText;
      newSingleParragraph.id=this.countTexts+"";
      this.countTexts++;
      this.actualParragraphs.push(newSingleParragraph);
     } else {
       this.showErrorMessage("No se puede añadir un texto al parrrafo sin estilo.");
     }
    
  }

  addParragraph(){
    let newParragraph=new Parragraph;
    newParragraph.style=new StyleModel;
    let splitter = this.parragraphStyle.id.split("###");
    if(splitter.length==2){
      newParragraph.style.id=splitter[0];
      newParragraph.style.name=splitter[1];
      newParragraph.id=this.countParragraph+"";
      this.countParragraph++;
      this.actualParragraphs.forEach(element => {
        newParragraph.texts.push(element);
      });
      this.actualParragraphs=[];
      this.parragraphs.push(newParragraph);
    } else {
      this.showErrorMessage("No se puede añadir un parrafo sin estilo.");
    }
 }

  deleteParragraph(id:number){
      this.parragraphs.splice(id, 1);
      let count=0;
      this.parragraphs.forEach(element => {
        element.id=count+"";
        count++;
      });
      this.countParragraph--;
    }

    deleteText(id:number){
      this.actualParragraphs.splice(id, 1);
      let count=0;
      this.actualParragraphs.forEach(element => {
        element.id=count+"";
        count++;
      });
      this.countTexts--;
    }

    addDocument(){
      let allValidations=true;
      let footer=new Footer;
      let splitterFooter = this.footerStyle.id.split("###");
      footer.style.id=splitterFooter[0];
      footer.style.name=splitterFooter[1];
      if(splitterFooter.length!=2){
        this.showErrorMessage("No se puede añadir un footer sin estilo.");
        allValidations=false;
      }
      footer.text=this.footer;
      let header=new Header;
      let splitterHeader = this.headerStyle.id.split("###");
      if(splitterHeader.length!=2 && allValidations){
        this.showErrorMessage("No se puede añadir un header sin estilo.");
        allValidations=false;
      }
      header.style.id=splitterHeader[0];
      header.style.name=splitterHeader[1];
      header.text=this.header;
      this.document.footer=footer;
      this.document.header=header;
      this.document.parragraphs=this.parragraphs;
      this.document.format.id=this.format.id;
      this.document.style.id=this.style.id;
      if(this.style.id.length==0 && allValidations){
        this.showErrorMessage("No se puede añadir un documento sin estilo.");
        allValidations=false;
      }
      if(this.format.id.length==0 && allValidations){
        this.showErrorMessage("No se puede añadir un documento sin formato.");
        allValidations=false;
      }
      if(allValidations==true){
        this.addNewDocument();
      }
    }

    documentAddedOk(){
      alert("Documento añadido correctamente");
      this.router.navigate((['/documents']));
    }
  
    addNewDocument(){
      let token=this.tokenManagment.getToken();
      this.documentService.newDocument(token, this.document).subscribe(response => this.documentAddedOk(), 
      error => this.showErrorMessage(error));
    }

  ngOnInit() {
  }

}
