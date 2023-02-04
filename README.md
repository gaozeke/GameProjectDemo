# GameProjectDemo

**置顶：**

宝箱动画消失的问题还未解决。现在宝箱触发后立刻消失，大概是不知道哪位的哪个脚本将它过早删除了，我也不知道该去哪修复。

一些建议：

1.请确保地图单元格的的缩放是(1,1,1)，这样不至于影响到它的子项

2.现在特效资源应该全都在Assets/Effects文件夹下。如果pull之后不是这个结构请删除所有特效内容，然后自建一个Effects文件夹塞进去。我怀疑这个push和pull在涉及到包的时候有点问题。

**更新内容：**

优化了相机动画。现在相机沿二次函数运动，实现推拉时视角俯仰的变化。

增加了一个Terran和对应的材质，现在地图不再浮空了。

备注：材质效果和自动地形材质一样，但是会自动挖空有地形/角色的区域避免干扰。原理是读取深度图做遮罩...所以如果想要在地图中挖个空洞，就随便放个什么只写入深度图但是不渲染的东西占位。

