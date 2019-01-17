import { UserRole } from "./Enum/UserRole";

export class EditUserDto {
  public userId: number;
  public name: string;
  public role: UserRole;
}
