import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivateChild,
  Router,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { Observable } from 'rxjs';
import { LocalStorageUtils } from '../utils/storage/local-storage-utils';

@Injectable({
  providedIn: 'root',
})
export class AgencyGuard implements CanActivateChild {
  constructor(private router: Router) {}

  canActivateChild(
    _childRoute: ActivatedRouteSnapshot,
    _state: RouterStateSnapshot
  ): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    const agencyToken = LocalStorageUtils.getAgencyToken();

    if (!agencyToken) {
      this.router.navigate(['/']);
      return false;
    }

    return true;
  }
}
