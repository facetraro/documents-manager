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
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-modify-document',
  templateUrl: './modify-document.component.html',
  styleUrls: ['./modify-document.component.css']
})
export class ModifyDocumentComponent implements OnInit {
  document:DocumentModel;
  footer:string;
  footerStyle:StyleModel;
  header:string;
  headerStyle:StyleModel;
  simpleText:string;
  simpleStyle:StyleModel;
  parragraphStyle:StyleModel;
  format:Format;
  style:string;
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
    router: Router,
    private activatedRoute: ActivatedRoute,
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
    this.style="";
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

    modifyDocument(){
      let allValidations=true;
      let footer=new Footer;
      footer.text=this.footer;
      console.log(this.footerStyle.id);
      footer.style.id=this.footerStyle.id;
      let header=new Header;
      header.style.id=this.headerStyle.id;
      header.text=this.header;
      this.document.footer=footer;
      this.document.header=header;
      this.document.parragraphs=this.parragraphs;
      this.document.format.id=this.format.id;
      this.document.style.id=this.style;
      if(this.style.length==0 && allValidations){
        this.showErrorMessage("No se puede añadir un documento sin estilo.");
        allValidations=false;
      }
      if(this.format.id.length==0 && allValidations){
        this.showErrorMessage("No se puede añadir un documento sin formato.");
        allValidations=false;
      }
      if(allValidations==true){
        this.modifyTheDocument();
      }
    }

    documentAddedOk(){
      alert("Documento añadido correctamente");
      this.router.navigate((['/documents']));
    }
  
    modifyTheDocument(){
      let token=this.tokenManagment.getToken();
      console.log(this.document);
      this.documentService.modifyDocument(token, this.document).subscribe(response => this.documentAddedOk(), 
      error => this.showErrorMessage(error));
    }

  ngOnInit() {
    let idDoc="";
    this.activatedRoute.queryParams
    .filter(params => params.idDoc)
    .subscribe(params => {
      idDoc = params.idDoc;
    });  
    let token=this.tokenManagment.getToken();
    this.loadDocument(token, idDoc);
  }
  loadDocument(token: string , id:string){
    this.documentService.getDocument(token, id).subscribe(response => {this.document=response; this.loadIntoUiDocument() }), 
      error => this.showErrorMessage(error);
  }
  loadIntoUiDocument(){
      this.footerStyle.id=this.document.footer.style.id;
      this.footerStyle.name=this.document.footer.style.name;
      this.headerStyle.id=this.document.header.style.id;
      this.headerStyle.name=this.document.header.style.name;
      this.format.id=this.document.format.id;
      this.format.name=this.document.format.name;
      this.style=this.document.style.id;
      console.log(this.style);
      this.footer=this.document.footer.text;
      this.header=this.document.header.text;
      this.parragraphs=this.document.parragraphs;
  }

}
