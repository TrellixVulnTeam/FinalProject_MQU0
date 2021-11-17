import { Component, OnInit } from '@angular/core';
import {ViewChild} from '@angular/core';
import {MatAccordion} from '@angular/material/expansion';
import {FormGroup, FormControl} from '@angular/forms';
import { SectionService } from 'src/app/Service/section.service';
import { UnitService } from 'src/app/Service/unit.service';
import { MatDialog } from '@angular/material/dialog';
import { CreateUnitComponent } from '../unit/create-unit/create-unit.component';
import { ExamServiceService } from 'src/app/Service/exam-service.service';
import { HttpClient } from '@angular/common/http';

import { faAngleDoubleRight, faShoppingCart, faHeart, faQuoteRight, faStar, faUser, faBook, faTag, faChartLine, faCalendar, faDollarSign, faPercentage, faEdit, faInfoCircle, faTrashAlt, faPlus} from '@fortawesome/free-solid-svg-icons';
import { AlertDialogComponent } from 'src/app/alert-dialog/alert-dialog.component';
import { CourseService } from 'src/app/Service/course.service';
import { CreateExamComponent } from '../exam/create-exam/create-exam.component';
import { CreateLectureComponent } from '../create-lecture/create-lecture.component';


@Component({
  selector: 'app-section',
  templateUrl: './section.component.html',
  styleUrls: ['./section.component.css']
})

export class SectionComponent implements OnInit {
 
@ViewChild(MatAccordion) accordion!: MatAccordion;
// @Input () SectionId: string| undefined;
// @Input () CourseId: string| undefined;
// @Input ()SectionTimeStart : Date| undefined;
// @Input ()SectionTimeEnd:Date | undefined;
// @Input ()  SectionCapacity:number| undefined;
// @Input () NoLecture: number| undefined;
// @Input () StatusId: number| undefined;
// @Input () IsActive: boolean| undefined;
// @Input () CreationDate:Date| undefined;
// @Input () CreatedBy: number| undefined;
  

  constructor(public sectionService: SectionService, private unitService: UnitService, private dialog:MatDialog,private examservice: ExamServiceService,
     private http: HttpClient) { }

  panelOpenState = false;

  faAngleDoubleRight = faAngleDoubleRight
  faShoppingCart = faShoppingCart
  faHeart = faHeart
  faQuoteRight = faQuoteRight
  faStar = faStar
  faUser = faUser
  faBook = faBook
  faTag = faTag
  faChartLine = faChartLine
  faCalendar = faCalendar
  faDollarSign = faDollarSign
  faPercentage = faPercentage
  faEdit =faEdit
  faInfoCircle = faInfoCircle
  faTrashAlt = faTrashAlt
  faPlus=faPlus

  sections:any=[{}];
  ngOnInit(): void {
    this.sectionService.ReturnAllTrainerSections(2);
    
    this.http.get('assets/ChatLog/1.txt', { responseType: 'text' }).subscribe(data => {
      const text = data;
      console.log(JSON.parse(text));
  });
  }

  CreateExam(SectionId:any){
    this.dialog.open(CreateExamComponent, {data : SectionId});
  }
  
  AddUnit(SectionId:any){
    this.dialog.open(CreateUnitComponent, {data : SectionId});
  }


  CreateMeeting(Section:any){
   this.dialog.open(CreateLectureComponent,{data : Section});
  }
}
