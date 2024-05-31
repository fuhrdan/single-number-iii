/**
 * Note: The returned array must be malloced, assume caller calls free().
 */

 //Struggled with malloc / calloc to return an array

int* singleNumber(int* nums, int numsSize, int* returnSize) {
    if (nums == NULL || returnSize == NULL)
        return 0;
    int first = 0;
    int second = 0;
    *returnSize = 2;
    int *retNum = (int *)calloc(*returnSize, sizeof(int));
    if(numsSize == 2)
    {
        first = nums[0];
        second = nums[1];
        retNum[0] = first;
        retNum[1] = second;
        return retNum;
    }
    int x = 0;
    int i;
    for(i = 0; i < numsSize; i++)
    {
        x ^= nums[i];
    }

    long k = 0;
    while(((x >> k) & 1) == 0)
        k++;
    if(k > 30) k = 30;
    for (i = 0; i < numsSize; i++)
    {
//        printf("nums[%d] = %d and k = %d\n",i,nums[i],k);
        if(nums[i] & (1 << k))
        {
            first ^= nums[i];
        }
        else
        {
            second ^= nums[i];
        }
    }

    retNum[0] = first;
    retNum[1] = second;

    return retNum;
}