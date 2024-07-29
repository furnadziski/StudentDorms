import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  @Output() saveSuccess: EventEmitter<any> = new EventEmitter();
  base64String: string | null = null;
  showUserInfo = false;
  user: any;

  constructor(
  ) { }

  ngOnInit(): void {
    this.getLoggedUser();
  }

  getLoggedUser(){
    //this.user = this.sessionStorageService.getUser();
  }

  refreshUser(){
    // this.sessionStorageService.removeUser();
    // this.saveSuccess.emit();
  }

  toggleUserInfo() {
    this.showUserInfo = !this.showUserInfo;
  }

}
