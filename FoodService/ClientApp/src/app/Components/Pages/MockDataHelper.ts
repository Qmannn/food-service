import { DishDto } from '../../../dto/Dish/DishDto';
import { DishCategory } from '../../../dto/Dish/DishCategory';

export class MockDataHelper {
    public static getMock(): DishDto[] {
        const dishDto1: DishDto = new DishDto();
        dishDto1.id = 0;
        dishDto1.name = 'First dish 1';
        dishDto1.description = ' dish description';
        dishDto1.price = 100;
        dishDto1.category = DishCategory.FirstDish;
        dishDto1.containerId = 1;

        const dishDto2: DishDto = new DishDto();
        dishDto2.id = 1;
        dishDto2.name = 'Second dish 1';
        dishDto2.description = ' dish description';
        dishDto2.price = 100;
        dishDto2.category = DishCategory.SecondDish;
        dishDto2.containerId = 1;

        const dishDto3: DishDto = new DishDto();
        dishDto3.id = 2;
        dishDto3.name = 'Garnish 1';
        dishDto3.description = ' dish description';
        dishDto3.price = 100;
        dishDto3.category = DishCategory.Garnish;
        dishDto3.containerId = 1;

        const dishDto4: DishDto = new DishDto();
        dishDto4.id = 3;
        dishDto4.name = 'Salad 1';
        dishDto4.description = ' dish description';
        dishDto4.price = 100;
        dishDto4.category = DishCategory.Salad;
        dishDto4.containerId = 1;

        const dishDto5: DishDto = new DishDto();
        dishDto5.id = 4;
        dishDto5.name = 'First dish 2';
        dishDto5.description = ' dish description';
        dishDto5.price = 100;
        dishDto5.category = DishCategory.FirstDish;
        dishDto5.containerId = 1;

        const dishDto6: DishDto = new DishDto();
        dishDto6.id = 5;
        dishDto6.name = 'Salad 2';
        dishDto6.description = ' dish description';
        dishDto6.price = 100;
        dishDto6.category = DishCategory.Salad;
        dishDto6.containerId = 1;

        const dishDto7: DishDto = new DishDto();
        dishDto7.id = 6;
        dishDto7.name = 'Garnish 2';
        dishDto7.description = ' dish description';
        dishDto7.price = 100;
        dishDto7.category = DishCategory.Garnish;
        dishDto7.containerId = 1;

        return [dishDto1, dishDto2, dishDto3, dishDto4, dishDto5, dishDto6, dishDto7];
      }
}
