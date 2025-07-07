import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-header',
  imports: [RouterModule],
  templateUrl: './header.html',
  styleUrl: './header.scss'
})
export class Header {
  isNavbarCollapsed = true;

  closeOffcanvas() {
    const offcanvas = document.getElementById('offcanvasNavbar');
    if (offcanvas) {
      // Bootstrap 5 Offcanvas API
      // @ts-ignore
      const bsOffcanvas = bootstrap.Offcanvas.getOrCreateInstance(offcanvas);
      bsOffcanvas.hide();
    }
  }
}
