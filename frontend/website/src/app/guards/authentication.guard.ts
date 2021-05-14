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
export class AuthenticationGuard implements CanActivateChild {
  constructor(private router: Router) {}

  canActivateChild(
    _childRoute: ActivatedRouteSnapshot,
    _state: RouterStateSnapshot
  ): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    const userToken = LocalStorageUtils.getUserToken();
    const agencyToken = LocalStorageUtils.getAgencyToken();

    if (!userToken && !agencyToken) {
      return true;
    }

    if (userToken && agencyToken) {
      LocalStorageUtils.clearStorage();
      return true;
    }

    if (userToken) {
      this.router.navigate(['/board']);
      return false;
    }

    if (agencyToken) {
      this.router.navigate(['/agency']);
      return false;
    }

    return true;
  }
}
