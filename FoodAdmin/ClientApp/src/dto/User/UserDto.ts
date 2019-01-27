import { UserRole } from './Enum/UserRole';

export class UserDto {
  public userId: number;
  public name: string;
  public role: UserRole;
}