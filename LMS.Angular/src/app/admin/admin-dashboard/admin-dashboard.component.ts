import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { faArrowUp, faShoppingCart, faUsers, faTicketAlt, faDollarSign, faBook, faSearch, faFileExcel, faFilePdf} from '@fortawesome/free-solid-svg-icons';
import { CourseService } from 'src/app/Service/course.service';
import * as XLSX from 'xlsx';
import jsPDF from "jspdf";
import autoTable from "jspdf-autotable"
@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css','../../../assets/css/style1.css']
})
export class AdminDashboardComponent implements OnInit {

  faArrowUp = faArrowUp
  faShoppingCart = faShoppingCart
  faUsers = faUsers
  faTicketAlt = faTicketAlt
  faDollarSign = faDollarSign
  faBook = faBook
  faSearch = faSearch
  faFileExcel = faFileExcel
  faFilePdf = faFilePdf

  availableYears:any[]=[{}]
  monthList:any[]=[{}]

  constructor(public courseService:CourseService) {

    this.courseService.returnSoldCourses;
    this.courseService.returnSoldCourses();
    this.courseService.getCourses();


    let max = new Date().getFullYear();
    let min = max - 20;
      max = max + 1;

    for(var i=min; i<=max; i++){
    this.availableYears.push({"id":i});
    }

    this.monthList = [
      { Value: 1, Text: 'Jan' },
      { Value: 2, Text: 'Feb' },
      { Value: 3, Text: 'Mar' },
      { Value: 4, Text: 'Apr' },
      { Value: 5, Text: 'May' },
      { Value: 6, Text: 'June' },
      { Value: 7, Text: 'July' },
      { Value: 8, Text: 'Aug' },
      { Value: 9, Text: 'Sep' },
      { Value: 10, Text: 'Oct' },
      { Value: 11, Text: 'Nov' },
      { Value: 12, Text: 'Dec' }
  ];

   }

  ngOnInit(): void {

    // this.courseService.returnSoldCourses();
    // this.courseService.getCourses();
  }

  startDate = new FormControl('');
  endDate = new FormControl('');

  filterSoldCourseBetweenDate(){

    this.courseService.filterSoldCourseBetweenDate(this.startDate,this.endDate);

  }


  year = new FormControl('');

  filterSoldCourse(){
    let selectionYear = this.year;
    this.courseService.filterSoldCourse(selectionYear);

  }
  
  month = new FormControl('');

  filterSoldCourseByMonth(){
    let selectionMonth = this.month;
    this.courseService.filterSoldCourseByMonth(selectionMonth);

  }


  clear(){
    this.courseService.soldCourse = this.courseService.annualSoldCourses;
    this.month = new FormControl('');
    this.year = new FormControl('');
    this.startDate = new FormControl('');
    this.endDate = new FormControl('');

  }


  @ViewChild('TABLE', { static: false }) TABLE: ElementRef | undefined;
  title = 'Excel';
  ExportTOExcel() {
    if(this.TABLE){
    const ws: XLSX.WorkSheet = XLSX.utils.table_to_sheet(this.TABLE.nativeElement);
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
    XLSX.writeFile(wb, 'Sales.xlsx');
    }
  }



  columns = [
    { title: "Id", dataKey: "checkoutId" },
    { title: "FirstName", dataKey: "firstName" },
    { title: "LastName", dataKey: "lastName" },
    { title: "PhoneNumber", dataKey: "phoneNumber" },
    { title: "PhoneNumber", dataKey: "courseName" },
    { title: "CoursePrice", dataKey: "coursePrice" },
    { title: "Date", dataKey: "creationDate" }
  ];

  soldCourses:any[]=[]

  exportPdf() {

    this.soldCourses = this.courseService.soldCourse
    const doc = new jsPDF('p','pt');

    autoTable(doc, {
      columns: this.columns,
      body: this.soldCourses,
      didDrawPage: (dataArg) => {
       doc.text('Sales', dataArg.settings.margin.left, 10);
      }
  });
    doc.save('sales.pdf');
  }
}
