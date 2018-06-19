import { Component, OnInit } from '@angular/core';
import { DocumentModel } from '../list-document/document-model';
import { Footer } from '../list-document/footer';
import { Header } from '../list-document/header';
import { Parragraph } from '../list-document/Parragraph';

@Component({
  selector: 'app-new-document',
  templateUrl: './new-document.component.html',
  styleUrls: ['./new-document.component.css']
})
export class NewDocumentComponent implements OnInit {
  document:DocumentModel;
  footer:Footer;
  header:Header;
  parragraphs:Parragraph;

  constructor() {
   }

  ngOnInit() {
  }

}
