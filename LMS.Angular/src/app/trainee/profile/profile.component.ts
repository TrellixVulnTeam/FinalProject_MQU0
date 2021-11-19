import { Component, OnInit } from '@angular/core';
import { ProfileService } from 'src/app/Service/profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css',
  '../../../assets/css/default.css',
  '../../../assets/css/slick.css',
  '../../../assets/css/style.css'
,'../../../assets/css/animate.css',
]
})
export class ProfileComponent implements OnInit {

  constructor(public profileService:ProfileService) { }

  ngOnInit(): void {
    let user:any = localStorage.getItem('user');
    let trainee = JSON.parse(user);
    //  if(traineeId){
    //  }
    this.profileService.GetMyProfile(parseInt(trainee.TraineeId))
  }

}
