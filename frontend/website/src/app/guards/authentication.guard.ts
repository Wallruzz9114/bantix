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
    const agentToken = LocalStorageUtils.getAgentToken();

    if (!userToken && !agentToken) {
      return true;
    }

    if (userToken && agentToken) {
      LocalStorageUtils.clearStorage();
      return true;
    }

    if (userToken) {
      this.router.navigate(['/board']);
      return false;
    }

    if (agentToken) {
      this.router.navigate(['/agent']);
      return false;
    }

    return true;
  }
}
