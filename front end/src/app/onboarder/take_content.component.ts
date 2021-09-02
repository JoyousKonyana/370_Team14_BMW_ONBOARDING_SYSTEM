import { Component } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';

@Component({
  templateUrl: './take_content.component.html'
})

export class Take_ContentComponent {

    ngOnInit() {
        
    }
    safeSrc: SafeResourceUrl;
    constructor(private sanitizer: DomSanitizer) { 
      this.safeSrc =  this.sanitizer.bypassSecurityTrustResourceUrl
      ("https://www.youtube.com/watch?v=3SoYkCAzMBk&list=RDMM&start_radio=1&rv=vx-Lzo9NxAQ");
    }
}
