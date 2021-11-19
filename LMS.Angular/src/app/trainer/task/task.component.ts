import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ExamService } from 'src/app/Service/exam.service';
import { SectionService } from 'src/app/Service/section.service';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css',
       '../../../assets/table/style.css']
})

export class TaskComponent implements OnInit {
TrainerSectionId:any|undefined;
  constructor(public examService:ExamService,
    private dialog: MatDialog,private router:Router
    ,public sections:SectionService) {

     
     }

  ngOnInit(): void {
 
  }
  DeleteExam(sectionId: number){};
  GetSolution(){
    this.router.navigate(['trainer','solution'])
  }
}
